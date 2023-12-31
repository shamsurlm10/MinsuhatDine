using System.Net;
using System.Text.Json;

namespace MinusThetaDine.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
 
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
 
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
 
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }
 
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
 
            if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            else if (exception is Exception) code = HttpStatusCode.BadRequest;
 
            var result = JsonSerializer.Serialize(new { error = "An error occured when processing your request" });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
 
            return context.Response.WriteAsync(result);
        }
    }
}
