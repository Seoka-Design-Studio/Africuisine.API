using System.Net;
using Africuisine.Application.Data.Config;
using Africuisine.Domain.Exceptions;
using Africuisine.Infrastructure.Services.Logger;
using Newtonsoft.Json;

namespace Africuisine.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILog logger;

        public ExceptionMiddleware(ILog logger, RequestDelegate next)
        {
            this.logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try
            {
                await _next(httpContext);
            }
            catch(Exception exception)
            {
                string message = $"An unexpected error occured. Error: {exception.Message} Exception: " + "{exception}";
                logger.Error(message, exception);
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        public async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            switch (exception)
            {
                case BaseException custom:
                    context.Response.StatusCode = (int)custom.Code;
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(
                            new Error { Code = (int)custom.Code, Message = custom.Message }
                        )
                    );
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(
                            new Error
                            {
                                Code = (int)HttpStatusCode.InternalServerError,
                                Message =
                                    "Something went wrong on our end. We're working hard to fix it." +
                                    "Please try again later or contact our support team if the issue persists."
                            }
                        )
                    );
                    break;
            }
        }
    }
}
