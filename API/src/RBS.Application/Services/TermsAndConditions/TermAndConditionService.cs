using RBS.Application.Models.TermsAndConditions;
using RBS.Data.Repositories;
using RBS.Domain.TermsAndConditions;

namespace RBS.Application.Services.TermsAndConditions
{
    public class TermAndConditionService : ITermAndConditionService
    {
        private readonly IRepository<TermAndCondition> _repository;

        public TermAndConditionService(IRepository<TermAndCondition> repository)
        {
            _repository = repository;
        }

        public async Task<List<TermAndConditionModel>> ListTermAndConditionByLanguag(string lang)
        {
            var termsAndConditions = await _repository.GetListAsync(x => x.Language.Key.Equals(lang));
            return termsAndConditions.Select(x => new TermAndConditionModel(x)).ToList();
        }
    }
}
