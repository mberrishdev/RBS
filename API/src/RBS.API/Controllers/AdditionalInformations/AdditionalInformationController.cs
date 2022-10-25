using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models;
using RBS.Application.Services.AdditionalInformations;

namespace RBS.API.Controllers.AdditionalInformations
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AdditionalInformationController : ApiControllerBase
    {
        private readonly IAdditionalInformationService _additionalInformationService;

        public AdditionalInformationController(IAdditionalInformationService additionalInformationService)
        {
            _additionalInformationService = additionalInformationService;
        }

        [HttpGet("GetAdditionalInformation/{restaurantId}")]
        [ProducesResponseType(typeof(List<AdditionalInformationModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AdditionalInformationModel>>> GetRestaurantImages([FromRoute] int restaurantId)
        {
            var result = await _additionalInformationService.GetAdditionalInformation(restaurantId);
            return Ok(result);
        }
    }
}
