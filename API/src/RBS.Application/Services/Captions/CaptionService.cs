using Common.Repository.Repository;
using RBS.Application.Models.Captions;
using RBS.Domain.TextContents;

namespace RBS.Application.Services.Captions
{
    public class CaptionService : ICaptionService
    {
        private readonly IQueryRepository<Caption> _queryRepository;

        public CaptionService(IQueryRepository<Caption> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<CaptionModel>> GetCaptions(int languageId, CancellationToken cancellationToken)
        {
            var captions = await _queryRepository.GetListAsync(predicate: x => x.LanguageId == languageId, cancellationToken: cancellationToken);
            return captions.Select(x => new CaptionModel(x)).ToList();
        }
    }
}
