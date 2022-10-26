using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.RestaurantModels;
using RBS.Application.Services.Restaurants;

namespace RBS.API.Controllers.Restaurant
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RestaurantController : ApiControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet("MainInformation/{id}")]
        [ProducesResponseType(typeof(List<RestaurantMainInformationModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<RestaurantMainInformationModel>> GetMainInformation([FromRoute] int id)
        {
            var result = await _restaurantService.GetMainInformation(id);
            return Ok(result);
        }

        [HttpGet]
        public ActionResult Search([FromQuery] DateTime date, [FromQuery] DateTime time, [FromQuery] int personCount, [FromQuery] string restaurant)
        {
            var result = new List<RestaruantSearchModel>
            {
                new RestaruantSearchModel()
                {
                    Id = 1,
                    Name = "Anis retorania bicho",
                    Location ="In Varketili",
                    Review = 5,
                    IsNew = true,
                    ImgSrc ="https://scontent.ftbs5-2.fna.fbcdn.net/v/t39.30808-6/307211817_1807108299643627_5046289176905459204_n.jpg?_nc_cat=103&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=o7Z2T-9H3wkAX8NWL9B&_nc_ht=scontent.ftbs5-2.fna&oh=00_AT9t8rdIhwqBvJ3OXSmjIVIA2ho1fWIG6PX2y5VbuSVHCQ&oe=635F4329",
                    ImgAlt = "anii",
                    FreeTime = new List<DateTime>()
                    {
                        DateTime.Now,
                        DateTime.Now.AddHours(2),
                    }
                },
                new RestaruantSearchModel()
                {
                    Id = 2,
                    Name = "Mikheil retorania bicho",
                    Location ="In VajaFshavela",
                    Review = 5,
                    ImgAlt = "mber",
                    FreeTime = new List<DateTime>()
                    {
                        DateTime.Now,
                        DateTime.Now.AddHours(4),
                        DateTime.Now.AddHours(4),
                        DateTime.Now.AddHours(5),
                        DateTime.Now.AddHours(1),
                        DateTime.Now.AddHours(5),
                        DateTime.Now.AddHours(7),
                        DateTime.Now.AddHours(9),
                    }
                }
            };

            return Ok(result);
        }
    }
}
