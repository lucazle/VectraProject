using SistemaFuncionarios.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace SistemaFuncionarios.API.Middlewares {
    public class ExceptionMiddleware {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware (RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            try {
                await _next(context);
            }
            catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync (HttpContext context, Exception ex) {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = ex switch {
                NotFoundException => (int)HttpStatusCode.NotFound,
                DuplicateException => (int)HttpStatusCode.Conflict,
                DomainException => (int)HttpStatusCode.BadRequest,
                _ => (int)HttpStatusCode.InternalServerError
            };

            var response = new {
                status = context.Response.StatusCode,
                message = ex.Message
            };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
