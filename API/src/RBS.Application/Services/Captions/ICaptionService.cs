using RBS.Application.Models.Captions;

namespace RBS.Application.Services.Captions
{
    public interface ICaptionService
    {
        Task<List<CaptionModel>> GetCaptions(int languageId, CancellationToken cancellationToken);
    }
}
