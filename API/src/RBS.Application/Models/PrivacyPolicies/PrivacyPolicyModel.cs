using RBS.Domain.PrivacyPolicies;

namespace RBS.Application.Models.PrivacyPolicies
{
    public class PrivacyPolicyModel
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Body { get; private set; }

        public PrivacyPolicyModel(PrivacyPolicy privacyPolicy)
        {
            Id = privacyPolicy.Id;
            Title = privacyPolicy.Title;
            Body = privacyPolicy.Body;
        }
    }
}
