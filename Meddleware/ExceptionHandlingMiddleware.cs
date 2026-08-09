using System.Text.Json;
using MedicalManagementSystem.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace MedicalManagementSystem.Meddleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
                _logger.LogError(ex, "Unhandled exception for {Method} {Path}", context.Request.Method, context.Request.Path);
                await HandleAsync(context, ex);
            }
        }

        private static async Task HandleAsync(HttpContext context, Exception ex)
        {
            var (status, message) = ex switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, ex.Message),
                BadRequestException => (StatusCodes.Status400BadRequest, ex.Message),
                DbUpdateException => (StatusCodes.Status409Conflict,
                    "The operation could not be completed. Please check that related records exist and the data is valid."),
                _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = status;

            var payload = JsonSerializer.Serialize(new
            {
                status,
                error = message
            });

            await context.Response.WriteAsync(payload);
        }
    }
}
