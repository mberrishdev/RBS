using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models;
using RBS.Application.Services.Countries;

namespace RBS.API.Controllers.Countries
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CountryController : ApiControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("ListOfCountry")]
        [ProducesResponseType(typeof(List<CountryModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountryModel>>> ListOfCountry(CancellationToken cancellationToken)
        {
            var result = await _countryService.ListOfCountry(cancellationToken);
            return Ok(result);
        }
    }
}
