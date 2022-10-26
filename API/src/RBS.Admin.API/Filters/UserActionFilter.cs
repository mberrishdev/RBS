using Microsoft.AspNetCore.Mvc.Filters;
using RBS.Admin.API.Controllers;

namespace RBS.Admin.API.Filters
{
    public class UserActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ApiControllerBase c = context.Controller as ApiControllerBase;
            if (c != null && c.User != null)
            {
                //c.UserModel = new UserModel
                //{
                //    UserName = c.User.FindFirstValue(ClaimTypes.Name),
                //    UserId = int.Parse(c.User.FindFirstValue(ClaimTypes.NameIdentifier)),
                //};
            }
        }
    }
}
