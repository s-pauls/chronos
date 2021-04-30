using System.Collections.Generic;
using System.Net;
using Chronos.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Organization.WebApi.PublicDataContract;

namespace Chronos.App.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is CustomException exception)
            {
                var content = new ApiResponse
                {
                    ErrorMessages = new List<string> {exception.Message}
                };

                var result = new ObjectResult(content)
                {
                    StatusCode = (int) HttpStatusCode.UnprocessableEntity
                };

                context.Result = result;
                context.ExceptionHandled = true;
            }
        }
    }
}
