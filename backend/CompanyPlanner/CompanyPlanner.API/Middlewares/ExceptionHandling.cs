using CompanyPlanner.Infrastructure.DTOs;

namespace CompanyPlanner.API.Middlewares
{
    public class ExceptionHandling(RequestDelegate next, ILogger<ExceptionHandling> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandling> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception occurred");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var response = ApiResponse<string>.Fail("An unexpected error occurred");
                var json = System.Text.Json.JsonSerializer.Serialize(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
