using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.Captions;
using RBS.Application.Services.Captions;

namespace RBS.API.Controllers.Captions
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CaptionsController : ApiControllerBase
    {
        private readonly ICaptionService _captionService;

        public CaptionsController(ICaptionService captionService)
        {
            _captionService = captionService;
        }

        [HttpGet("{languageId}")]
        [ProducesResponseType(typeof(List<CaptionModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CaptionModel>>> Captions(int languageId)
        {
            var result = await _captionService.GetCaptions(languageId);
            return Ok(result);
        }
    }
}
