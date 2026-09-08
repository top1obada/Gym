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
                await _next(context); // تمرير الطلب للـ Middleware التالي
            }
            catch (Exception ex)
            {
                // تسجيل الاستثناء باستخدام ILogger
                _logger.LogError(ex, "Unhandled exception occurred on request {Path}", context.Request.Path);

                // إرسال Response موحد للعميل
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new { Error = "Internal Server Error" });
            }
        }
    }
}
