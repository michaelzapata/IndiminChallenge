using MediatR;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Indimin.Challenge.Logging.Pipelines
{
    public class LoggingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private ILogger _logger;
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger = Log.ForContext<TRequest>();
            try
            {
                _logger.Debug("Executing next()");
                var response = await next();
                _logger.Debug("Response method: {method}", JsonConvert.SerializeObject(response));
                return response;
            }
            catch (Exception ex)
            {
                _logger.Error("Ha ocurrido un error: {error}", ex);
                throw;
            }
        }
    }
}
