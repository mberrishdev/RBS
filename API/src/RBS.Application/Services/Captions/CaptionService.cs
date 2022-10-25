using RBS.Application.Models.Captions;
using RBS.Data.Repositories;
using RBS.Domain.TextContents;

namespace RBS.Application.Services.Captions
{
    public class CaptionService : ICaptionService
    {
        private readonly IRepository<Caption> _repository;

        public CaptionService(IRepository<Caption> repository)
        {
            _repository = repository;
        }

        public async Task<List<CaptionModel>> GetCaptions(int languageId)
        {
            var captions = await _repository.GetListAsync(x => x.LanguageId == languageId);
            return captions.Select(x => new CaptionModel(x)).ToList();
        }
    }
}
