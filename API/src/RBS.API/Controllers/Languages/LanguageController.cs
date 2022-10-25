using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.Languages;
using RBS.Application.Services.Languages;

namespace RBS.API.Controllers.Languages
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<LanguageModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<LanguageModel>>> GetAllLanguages()
        {
            var result = await _languageService.GetAllLanguages();
            return Ok(result);
        }
    }
}
