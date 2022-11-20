using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.PrivacyPolicies;
using RBS.Application.Services.PrivacyPolicies;

namespace RBS.API.Controllers.PrivacyPolicies
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PrivacyPoliciesController : ControllerBase
    {
        private readonly IPrivacyPolicyService _privacyPolicyService;

        public PrivacyPoliciesController(IPrivacyPolicyService privacyPolicyService)
        {
            _privacyPolicyService = privacyPolicyService;
        }

        [HttpGet("{lang}")]
        public async Task<ActionResult<PrivacyPolicyModel>> ListPrivacyPolicyByLanguage([FromRoute] string lang, CancellationToken cancellationToken)
        {
            var response = await _privacyPolicyService.ListPrivacyPolicyByLanguage(lang, cancellationToken);
            return Ok(response);
        }
    }
}
