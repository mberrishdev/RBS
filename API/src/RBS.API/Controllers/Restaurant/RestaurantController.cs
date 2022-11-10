using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.RestaurantModels;
using RBS.Application.Services.Restaurants;
using RBS.Application.Services.Restaurants.Queries;
using RBS.Domain.Enums;

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
        public async Task<ActionResult> GetMainInformation([FromRoute] int id)
        {
            var result = await _restaurantService.GetMainInformation(id);
            return Ok(result);
        }

        [HttpGet("Search")]
        [ProducesResponseType(typeof(List<RestaruantSearchModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RestaruantSearchModel>>> Search([FromQuery] DateTime date, [FromQuery] DateTime time, [FromQuery] int personCount, [FromQuery] string restaurant, [FromQuery] int orderById)
        {
            var query = new RestaurantSearchQuery()
            {
                OrderBy = (RestaurantOrderType)orderById,
                UserModel = UserModel,
            };

            var result = await _restaurantService.Search(query);
            return Ok(result);
        }
    }
}
