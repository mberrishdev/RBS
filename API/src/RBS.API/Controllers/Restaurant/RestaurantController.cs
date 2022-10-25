using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models;
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
    }
}
