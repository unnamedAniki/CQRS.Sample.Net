using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Sample.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sample.API.Infrastructure
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExeptionMiddleware> logger;

        public ExeptionMiddleware(RequestDelegate next, ILogger<ExeptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (BusinessLogicException e)
            {
                await SendResponse(httpContext, e.Message, HttpStatusCode.BadRequest, e);
            }
            catch (Exception e)
            {
                await SendResponse(httpContext, "Unknown error", HttpStatusCode.InternalServerError, e);
                logger.LogError(e, "Unknown error");
            }
        }

        private async Task SendResponse(HttpContext httpContext, string message, HttpStatusCode statusCode, Exception e)
        {
            if (httpContext.Response.HasStarted)
                throw e;

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = (int)statusCode;
            httpContext.Response.ContentType = "application/json";
            var problemDetail = new ProblemDetails
            {
                Title = message,
                Status = (int)statusCode
            };
            // ReSharper disable once MethodHasAsyncOverload
            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(problemDetail));
        }
    }
}
