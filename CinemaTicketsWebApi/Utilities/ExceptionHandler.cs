using System.Net;

namespace CinemaTicketsWebApi.Utilities
{
    public static class ExceptionHandler
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder appBuilder)
        {
            return appBuilder.UseExceptionHandlingMiddleware(new Dictionary<Type, HttpStatusCode>());
        }

        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder appBuilder, IDictionary<Type, HttpStatusCode> handledExceptions)
        {
            if (handledExceptions == null)
            {
                handledExceptions = new Dictionary<Type, HttpStatusCode>();
            }

            return appBuilder.UseMiddleware(typeof(ErrorHandlingMiddleware), handledExceptions);
        }
    }
}
