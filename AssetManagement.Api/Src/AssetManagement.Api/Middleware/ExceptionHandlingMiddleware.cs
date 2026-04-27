
using System.Text.Json;

namespace AssetManagement.Api.Middleware
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
       
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var respone = context.Response;
                respone.ContentType = "application/json";
                respone.StatusCode = ex switch
                {
                    KeyNotFoundException => 404,
                    UnauthorizedAccessException => 401,
                    InvalidOperationException => 400,
                    _ => 500
                };

                var result = JsonSerializer.Serialize(new { messsage = ex?.Message });
                await respone.WriteAsync(result);
            }
        }
    }

    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
           return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
