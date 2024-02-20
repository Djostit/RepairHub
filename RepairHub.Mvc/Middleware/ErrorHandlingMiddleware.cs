using FluentValidation;
using Newtonsoft.Json;
using RepairHub.Mvc.Models;

namespace RepairHub.Mvc.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/problem+json";
                context.Response.StatusCode = 400;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Errors
                    .Select(x => new ProblemDetail
                    {
                        PropertyName = x.PropertyName,
                        ErrorMessage = x.ErrorMessage
                    }).ToList()));
            }
        }

    }
}
