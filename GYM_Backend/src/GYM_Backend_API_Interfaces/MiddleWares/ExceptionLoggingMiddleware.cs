using Microsoft.Data.SqlClient;
using System.Net;

namespace Gym_Backend_MiddleWares
{
    public class ExceptionLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionLoggingMiddleware> _logger;

        public ExceptionLoggingMiddleware(RequestDelegate next, ILogger<ExceptionLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred on request {Path}", context.Request.Path);

                var statusCode = (int)HttpStatusCode.InternalServerError;
                string clientMessage = "An unexpected server error occurred.";

                if (ex is SqlException sqlEx)
                {
                    if (sqlEx.Number == 50000)
                    {
                        statusCode = (int)HttpStatusCode.BadRequest;
                        clientMessage = sqlEx.Message;
                    }
                    else
                    {
                        clientMessage = "A database error occurred while processing your request.";
                    }
                }

                context.Response.StatusCode = statusCode;
                context.Response.ContentType = "application/json";

                await context.Response.WriteAsJsonAsync(new
                {
                    success = false,
                    error = clientMessage
                });
            }
        }
    }
}