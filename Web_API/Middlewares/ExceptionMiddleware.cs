
using Real_App.Errors;
using System.Net;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Real_App.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostingEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, 
               ILogger<ExceptionMiddleware> logger,
               IHostingEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex) 
            {
                ApiError response;
                HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
                string message;
                var exceptionType = ex.GetType();

                if (exceptionType == typeof(UnauthorizedAccessException))
                {
                    statusCode = HttpStatusCode.Forbidden;
                    message = "You are not authorized";
                }
                else
                {
                    statusCode = HttpStatusCode.InternalServerError;
                    message = "Some unknown error occoured";
                }
                if (_env.IsDevelopment())
                {
                    response = new ApiError((int)statusCode, message, ex.StackTrace.ToString());
                }
                else
                {
                    response = new ApiError((int)statusCode, message);
                }

                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)statusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(response.ToString());
            }
        }
    }
}
