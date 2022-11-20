using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.TermsAndConditions;
using RBS.Application.Services.TermsAndConditions;

namespace RBS.API.Controllers.TermsAndConditions
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TermsAndConditionsController : ControllerBase
    {
        private readonly ITermAndConditionService _termAndConditionService;

        public TermsAndConditionsController(ITermAndConditionService termAndConditionService)
        {
            _termAndConditionService = termAndConditionService;
        }

        [HttpGet("{lang}")]
        public async Task<ActionResult<TermAndConditionModel>> ListTermAndConditionByLanguage([FromRoute] string lang, CancellationToken cancellationToken)
        {
            var response = await _termAndConditionService.ListTermAndConditionByLanguag(lang, cancellationToken);
            return Ok(response);
        }
    }
}
