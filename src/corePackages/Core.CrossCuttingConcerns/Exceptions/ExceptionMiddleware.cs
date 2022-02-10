using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Core.CrossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            object errors = null;

            if (ex.GetType() == typeof(ValidationException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errors = ((ValidationException)ex).Errors;
                return context.Response.WriteAsync(new ValidationProblemsDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://example.com/probs/validation",
                    Title = "Validation error(s)",
                    Detail = "",
                    Instance = "",
                    Errors = errors,
                }.ToString());
            }

            if (ex.GetType() == typeof(BusinessException))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                return context.Response.WriteAsync(new BusinessProblemsDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://example.com/probs/business",
                    Title = "Business exeption",
                    Detail = ex.Message,
                    Instance = "",
                }.ToString());
            }

            return context.Response.WriteAsync(new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://example.com/probs/internal",
                Title = "Internal exeption",
                Detail = ex.Message,
                Instance = "",
            }.ToString());
        }
    }
}
