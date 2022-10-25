using RBS.Application.Models.PrivacyPolicies;
using RBS.Data.Repositories;
using RBS.Domain.PrivacyPolicies;

namespace RBS.Application.Services.PrivacyPolicies
{
    public class PrivacyPolicyService : IPrivacyPolicyService
    {
        private readonly IRepository<PrivacyPolicy> _repository;

        public PrivacyPolicyService(IRepository<PrivacyPolicy> repository)
        {
            _repository = repository;
        }

        public async Task<List<PrivacyPolicyModel>> ListPrivacyPolicyByLanguage(string lang)
        {
            var privacyPolicies = await _repository.GetListAsync(x => x.Language.Key.Equals(lang));
            return privacyPolicies.Select(x => new PrivacyPolicyModel(x)).ToList();
        }
    }
}
