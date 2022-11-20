using Common.Repository.Repository;
using RBS.Application.Models;
using RBS.Domain.AdditionalInformations;

namespace RBS.Application.Services.AdditionalInformations
{
    public class AdditionalInformationService : IAdditionalInformationService
    {
        private readonly IQueryRepository<AdditionalInformation> _queryRepository;

        public AdditionalInformationService(IQueryRepository<AdditionalInformation> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<AdditionalInformationModel>> GetAdditionalInformation(int restaurantId, CancellationToken cancellationToken)
        {
            var additionalInformation = await _queryRepository.GetListAsync(predicate: x => x.RestaurantId == restaurantId, cancellationToken: cancellationToken);

            return additionalInformation.Select(x => new AdditionalInformationModel(x)).ToList();
        }
    }
}
