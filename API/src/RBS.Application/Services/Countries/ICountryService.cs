using RBS.Application.Models;

namespace RBS.Application.Services.Countries
{
    public interface ICountryService
    {
        Task<List<CountryModel>> ListOfCountry();
    }
}
