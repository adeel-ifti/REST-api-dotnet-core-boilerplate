using AlphaCompanyWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace AlphaCompanyWebApi.Infrastructure
{
    public sealed class TokenAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var httpConext = (HttpRequest)context.HttpContext.Request;

            if (string.IsNullOrEmpty(httpConext.GetBearerToken()))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
