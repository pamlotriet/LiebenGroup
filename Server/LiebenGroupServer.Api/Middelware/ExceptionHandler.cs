using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace LiebenGroupServer.Api.Middelware
{
    public class ExceptionHandler
    {

        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                KeyNotFoundException => (int)HttpStatusCode.NotFound, 
                ValidationException => (int)HttpStatusCode.BadRequest, 
                DbUpdateConcurrencyException => (int)HttpStatusCode.Conflict,
                DbUpdateException => (int)HttpStatusCode.InternalServerError,
                InvalidOperationException => (int)HttpStatusCode.Conflict, 
                _ => (int)HttpStatusCode.InternalServerError
            };

            var errorResponse = new
            {
                statusCode,
                message = ex.Message,
                details = statusCode == 500 ? "An unexpected error occurred." : ex.Message
            };


            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }

}
