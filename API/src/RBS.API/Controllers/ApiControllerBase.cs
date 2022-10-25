using Microsoft.AspNetCore.Mvc;
using RBS.API.Filters;
using RBS.Domain.UserInfo;

namespace RBS.API.Controllers
{
    [ApiController]
    [UserActionFilter]
    [Produces("application/json")]
    public class ApiControllerBase : ControllerBase
    {
        public UserModel UserModel { get; set; }
    }
}
