using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace BuberDinner.Api.Middlewares {
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate _next) {
            this._next = _next;
        }
        public async Task InvokeAsync(HttpContext context) {
            try {
                // Buffer the request body
                context.Request.EnableBuffering();
                await _next(context);
            } catch (Exception ex) {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception ex) {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var requestBody = await GetRequestBodyAsync(context);
            var errorResponse = new {
                EndPoint = context.Request.Path,
                Message = "An error occured while processing your request",
                Exception = ex.Message,
                RequestBody = JsonDocument.Parse(requestBody)

            };
            var result = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(result);
        }
        private static async Task<string> GetRequestBodyAsync(HttpContext context) {
            var requestBody = string.Empty;

            var request = context.Request;
            if (request.ContentLength != null && request.ContentLength > 0 && request.Body.CanSeek) {
                request.Body.Seek(0, SeekOrigin.Begin);
                using var reader = new StreamReader(request.Body);
                requestBody = await reader.ReadToEndAsync();
                request.Body.Seek(0, SeekOrigin.Begin);
            }

            return requestBody;

        }
    }
}
