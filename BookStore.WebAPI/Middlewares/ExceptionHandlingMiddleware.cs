
using BookStore.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
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
                context.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    AuthException => StatusCodes.Status401Unauthorized,
                    _ => StatusCodes.Status500InternalServerError
                };

                await context.Response.WriteAsJsonAsync(
                    new ProblemDetails
                    {
                        Type = ex.GetType().Name,
                        Title = ex switch
                        {
                            NotFoundException => "Not found",
                            AuthException => "Auth Exception",
                            _ => "Internal Server error"
                        },
                        Detail = ex.Message
                    });
            }
        }
    }
}
