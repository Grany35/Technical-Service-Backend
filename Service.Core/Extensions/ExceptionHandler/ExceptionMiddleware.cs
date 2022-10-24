using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Service.Core.Extensions.ExceptionHandler.ErrorHandlerDetails;

namespace Service.Core.Extensions.ExceptionHandler
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {

                await HandleExceptionAsync(httpContext, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message;
            IEnumerable<ValidationFailure> errors;

            if (exception.GetType() == typeof(ValidationException))
            {
                message = exception.Message;
                errors = ((ValidationException)exception).Errors;

                return httpContext.Response.WriteAsync(new ValidationErrorDetails
                {
                    Message = message,
                    Errors = errors,
                    StatusCode = 400
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ErrorHandlerDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = exception.Message,
            }.ToString());
        }
    }
}
