using System.Net;
using System.Text.Json;

namespace ServiceCenterManagement.Middleware
{
    public class ExceptionMiddleware
    {
       
            private readonly RequestDelegate next;

            public ExceptionMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        statusCode = 500,
                        message = "An unexpected error occurred",
                        error = ex.Message
                    };

                    await context.Response.WriteAsync(
                        JsonSerializer.Serialize(response));
                }
            }
        
    }
}

