using Microsoft.AspNetCore.Mvc;
using RBS.Admin.API.Filters;
using RBS.Domain.UserInfo;

namespace RBS.Admin.API.Controllers
{
    [ApiController]
    [UserActionFilter]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        public UserModel UserModel { get; set; }
    }
}
