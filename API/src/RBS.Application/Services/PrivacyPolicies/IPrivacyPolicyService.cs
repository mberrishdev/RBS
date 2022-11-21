using RBS.Application.Models.PrivacyPolicies;

namespace RBS.Application.Services.PrivacyPolicies
{
    public interface IPrivacyPolicyService
    {
        Task<List<PrivacyPolicyModel>> ListPrivacyPolicyByLanguage(string lang, CancellationToken cancellationToken);
    }
}
