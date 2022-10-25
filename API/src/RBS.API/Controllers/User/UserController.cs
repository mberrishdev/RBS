using Microsoft.AspNetCore.Mvc;

namespace RBS.API.Controllers.User
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ApiControllerBase
    {

    }

    public class GuestUserRestrationCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
