using RBS.Application.Models;
using RBS.Data.Repositories;
using RBS.Domain.AdditionalInformations;

namespace RBS.Application.Services.AdditionalInformations
{
    public class AdditionalInformationService : IAdditionalInformationService
    {
        private readonly IRepository<AdditionalInformation> _repository;

        public AdditionalInformationService(IRepository<AdditionalInformation> repository)
        {
            _repository = repository;
        }

        public async Task<List<AdditionalInformationModel>> GetAdditionalInformation(int restaurantId)
        {
            var additionalInformation = await _repository.GetListAsync(predicate: x => x.RestaurantId == restaurantId);

            return additionalInformation.Select(x => new AdditionalInformationModel(x)).ToList();
        }
    }
}
