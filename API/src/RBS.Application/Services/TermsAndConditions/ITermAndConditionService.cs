using RBS.Application.Models.TermsAndConditions;

namespace RBS.Application.Services.TermsAndConditions
{
    public interface ITermAndConditionService
    {
        Task<List<TermAndConditionModel>> ListTermAndConditionByLanguag(string lang, CancellationToken cancellationToken);
    }
}
