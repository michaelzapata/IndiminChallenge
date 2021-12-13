using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Indimin.Challenge.Logging.Proxies
{
    public class LoggingProxy<TDecorated> : DispatchProxy
    {
        private TDecorated _decorated;
        private ILogger _logger;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            _logger = Log.ForContext((_decorated.GetType().GetTypeInfo()).UnderlyingSystemType);
            using (LogContext.PushProperty("MethodName", targetMethod.Name))
            {
                try
                {
                    var arguments = JsonConvert.SerializeObject(args);
                    _logger.Information("Invoking {methodName}", targetMethod.Name);
                    _logger.Information("Initializing Method");
                    _logger.Debug("Requested method: {method}", targetMethod.Name);
                    _logger.Debug("Requested method arguments: {requestedParameters}", arguments.Length > 5000 ? "*********" : arguments);
                    var result = targetMethod.Invoke(_decorated, args);
                    if (result is Task resultTask)
                    {
                        resultTask.ContinueWith(task =>
                        {
                            if (task.IsFaulted)
                            {
                                _logger.Error(task.Exception,
                                    "An unhandled exception was raised during execution of {methodName}", typeof(TDecorated), targetMethod.Name);
                            }

                            var property = task.GetType()
                                   .GetTypeInfo()
                                   .GetProperties()
                                   .FirstOrDefault(p => p.Name == "Result");
                            if (property != null)
                            {
                                _logger.Information("Response method {methodName} result: {task}", targetMethod.Name, JsonConvert.SerializeObject(property.GetValue(task)));
                            }
                        });
                    }
                    else
                    {
                        _logger.Information("Invoking {decoratedClass}.{methodName} completed.",
                            typeof(TDecorated), targetMethod.Name);
                    }

                    return result;
                }
                catch (TargetInvocationException ex)
                {
                    _logger.Error(ex.InnerException ?? ex,
                        "Error during invocation of {decoratedClass}.{methodName}",
                        typeof(TDecorated), targetMethod.Name);
                    throw ex.InnerException ?? ex;
                }
            }

        }

        public static TDecorated Create(TDecorated decorated)
        {
            object proxy = Create<TDecorated, LoggingProxy<TDecorated>>();
            ((LoggingProxy<TDecorated>)proxy).SetParameters(decorated);

            return (TDecorated)proxy;
        }

        private void SetParameters(TDecorated decorated)
        {
            _logger = Log.ForContext<LoggingProxy<TDecorated>>();
            _decorated = decorated ?? throw new ArgumentNullException(nameof(decorated));
        }
    }
}
