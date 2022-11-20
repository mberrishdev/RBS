using Common.Repository.Repository;
using RBS.Application.Models;
using RBS.Domain.Countries;

namespace RBS.Application.Services.Countries
{
    public class CountryService : ICountryService
    {
        private readonly IQueryRepository<Country> _queryRepository;

        public CountryService(IQueryRepository<Country> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<CountryModel>> ListOfCountry(CancellationToken cancellationToken)
        {
            var countries = await _queryRepository.GetListAsync(cancellationToken: cancellationToken);

            return countries.Select(x => new CountryModel(x)).ToList();
        }
    }
}
