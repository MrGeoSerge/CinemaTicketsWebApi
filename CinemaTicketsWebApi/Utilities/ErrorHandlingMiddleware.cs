using Microsoft.Rest;
using Newtonsoft.Json;
using System.Net;

namespace CinemaTicketsWebApi.Utilities
{
    internal class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDictionary<Type, HttpStatusCode> _handledExceptions;

        public ErrorHandlingMiddleware(
            RequestDelegate next,
            IDictionary<Type, HttpStatusCode> handledExceptions)
        {
            _handledExceptions = handledExceptions;
            _next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, env.IsDevelopment());
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, bool isDevelopment)
        {
            var httpStatusCode = (int)GetCode(exception);
            var responseBody = GetResponseBody(exception, isDevelopment, httpStatusCode);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpStatusCode;

            return context.Response.WriteAsync(responseBody);
        }

        private HttpStatusCode GetCode(Exception exception)
        {
            var exceptionToHandle = (exception as AggregateException)?.InnerExceptions.First() ?? exception;

            var exceptionType = exceptionToHandle.GetType();
            if (_handledExceptions.TryGetValue(exceptionType, out HttpStatusCode httpCode))
            {
                return httpCode;
            }

            return HttpStatusCode.InternalServerError;
        }

        private static string GetResponseBody(Exception exception, bool isDevelopment, int httpStatusCode)
        {
            var exceptionToHandle = (exception as AggregateException)?.InnerExceptions.First() ?? exception;

            string errorMessage;
            if (isDevelopment)
            {
                errorMessage = exception.ToString();
            }
            else if (httpStatusCode > 300 && httpStatusCode < 500)
            {
                errorMessage = exception.Message;
            }
            else
            {
                errorMessage = "Something wrong happened";
            }

            switch (exceptionToHandle)
            {
                case HttpOperationException operationException:
                    errorMessage = operationException.Response.Content;
                    break;
                default:
                    errorMessage = JsonConvert.SerializeObject(new { error = errorMessage });
                    break;
            }

            return errorMessage;
        }
    }
}
