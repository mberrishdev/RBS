using RBS.Application.Models;
using RBS.Data.Repositories;
using RBS.Domain.Countries;

namespace RBS.Application.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _repository;

        public CountryService(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<List<CountryModel>> ListOfCountry()
        {
            var countries = await _repository.GetListAsync();

            return countries.Select(x => new CountryModel(x)).ToList();
        }
    }
}
