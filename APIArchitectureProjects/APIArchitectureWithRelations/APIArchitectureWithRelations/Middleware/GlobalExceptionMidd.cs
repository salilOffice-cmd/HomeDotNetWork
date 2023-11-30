using APIArchitectureWithRelations.Helper;
using System.Net;

namespace APIArchitectureWithRelations.Middleware
{
    public class GlobalExceptionMidd
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMidd(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                //var body = context.Response.Body;
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }


        private async Task HandleException(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // 500

            ErrorResponse errorResponse = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
                Source = context.Request.Path,
            };

            await context.Response.WriteAsync(errorResponse.ToString());
        }
    }
}
