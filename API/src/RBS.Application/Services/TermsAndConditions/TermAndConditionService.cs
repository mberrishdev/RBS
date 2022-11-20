using Common.Repository.Repository;
using RBS.Application.Models.TermsAndConditions;
using RBS.Domain.TermsAndConditions;

namespace RBS.Application.Services.TermsAndConditions
{
    public class TermAndConditionService : ITermAndConditionService
    {
        private readonly IQueryRepository<TermAndCondition> _queryRepository;

        public TermAndConditionService(IQueryRepository<TermAndCondition> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<TermAndConditionModel>> ListTermAndConditionByLanguag(string lang, CancellationToken cancellationToken)
        {
            var termsAndConditions = await _queryRepository.GetListAsync(predicate: x => x.Language.Key.Equals(lang), cancellationToken: cancellationToken);
            return termsAndConditions.Select(x => new TermAndConditionModel(x)).ToList();
        }
    }
}
