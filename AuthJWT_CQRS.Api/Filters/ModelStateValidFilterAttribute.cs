using AuthJWT_CQRS.Business.CQRS.Models.Base;
using AuthJWT_CQRS.Business.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWT_CQRS.Api.Filters
{
    public class ModelStateValidFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(new ResponseModelError { Error = ErrorHandlerHelper.MODEL_VALIDATION_ERROR });
            }
        }
    }
}
