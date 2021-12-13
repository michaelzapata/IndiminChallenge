using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Indimin.Challenge.Logging.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            _logger = Log.ForContext<LoggingMiddleware>();
        }
        public async Task Invoke(HttpContext context)
        {
            MemoryStream responseBodyStream = new MemoryStream();
            Stream originalBodyStream = context.Response.Body;
            var sw = new Stopwatch();

            using (LogContext.PushProperty("TraceId", context.TraceIdentifier))
            {
                try
                {
                    _logger.Information("Initializing Request");
                    _logger.Debug("Request url: {method} : {request}", context.Request.Method, context.Request.GetDisplayUrl());
                    _logger.Debug("Request body: {requestBody}", JsonConvert.SerializeObject(await GetRequestBody(context.Request)));

                    context.Response.Body = responseBodyStream;

                    await _next.Invoke(context);
                }
                catch(Exception ex)
                {
                    _logger.Error(ex.Message);
                    context.Response.StatusCode = 500;
                }
                finally
                {
                    HttpStatusCode resposeStatusCode = (HttpStatusCode)context.Response.StatusCode;
                    string responseBody = await GetResponse(context.Response);

                    await responseBodyStream.CopyToAsync(originalBodyStream);

                    sw.Stop();

                    _logger.Debug("Response: {statusCode} {statusCodeString} -> {response}", (int)resposeStatusCode, resposeStatusCode, responseBody);
                    _logger.Information("Request finished in {elapsedMilliseconds}ms [{statusCode} {statusCodeString}]", sw.ElapsedMilliseconds, (int)resposeStatusCode, resposeStatusCode);
                }
            }


        }
        private async Task<string> GetRequestBody(HttpRequest request)
        {
            request.EnableBuffering();

            var bodyStreamReader = new StreamReader(request.Body);
            var bodyString = await bodyStreamReader.ReadToEndAsync();
            request.Body.Position = 0;

            return bodyString;
        }

        private async Task<string> GetResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var bodyString = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return bodyString;
        }
    }

}
