using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System.Linq;

namespace Indimin.Challenge.Logging.Filters
{
    public class LoggingFilter : IActionFilter
    {
        private readonly IDiagnosticContext _diagnosticContext;
        private ILogger _logger;

        public LoggingFilter(IDiagnosticContext diagnosticContext)
        {
            _diagnosticContext = diagnosticContext;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var methodName = (string)context.RouteData.Values.Values.FirstOrDefault();
            using (LogContext.PushProperty("MethodName", methodName))
            {
                var result = context.Result;
                if (context.Exception != null)
                {
                    // Exception thrown by action or action filter.
                    // Set to null to handle the exception.
                    _logger.Error("Exception: {0}", context.Exception.Message);
                }
                _logger.Information("Result: {0}", JsonConvert.SerializeObject(result as OkObjectResult));
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger = Log.ForContext<LoggingFilter>();
            var methodName = (string)context.RouteData.Values.Values.FirstOrDefault();
            using (LogContext.PushProperty("MethodName", methodName))
            {
                var actionParamatersValues = JsonConvert.SerializeObject(context.ActionArguments.Values);
                _logger.Information("Initializing Method");
                _logger.Information("Action: {0}", context.ActionDescriptor.DisplayName);
                _logger.Information("ActionParameters: {0}", context.ActionArguments);
                _logger.Information("ActionParametersValues: {0}", actionParamatersValues);
                _logger.Information("ModeStateValid: {0}", context.ModelState.IsValid);
            }
        }
    }
}
