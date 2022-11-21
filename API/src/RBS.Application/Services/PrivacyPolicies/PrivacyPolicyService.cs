using Common.Repository.Repository;
using RBS.Application.Models.PrivacyPolicies;
using RBS.Domain.PrivacyPolicies;

namespace RBS.Application.Services.PrivacyPolicies
{
    public class PrivacyPolicyService : IPrivacyPolicyService
    {
        private readonly IQueryRepository<PrivacyPolicy> _queryRepository;

        public PrivacyPolicyService(IQueryRepository<PrivacyPolicy> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<PrivacyPolicyModel>> ListPrivacyPolicyByLanguage(string lang, CancellationToken cancellationToken)
        {
            var privacyPolicies = await _queryRepository.GetListAsync(predicate: x => x.Language.Key.Equals(lang), cancellationToken: cancellationToken);
            return privacyPolicies.Select(x => new PrivacyPolicyModel(x)).ToList();
        }
    }
}
