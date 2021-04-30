using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Organization.WebApi.PublicDataContract;

namespace Chronos.App.Filters
{
    public class HttpRequestModelStateFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var content = new ApiResponse
                {
                    ErrorMessages = context.ModelState.Values.Where(v => v.Errors.Any())
                        .SelectMany(v => v.Errors)
                        .Select(v => v.ErrorMessage)
                        .ToList()
                };

                var result = new JsonResult(content)
                {
                    StatusCode = (int)HttpStatusCode.BadRequest
                };

                context.Result = result;

            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}
