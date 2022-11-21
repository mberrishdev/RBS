using RBS.Application.Models.Languages;

namespace RBS.Application.Services.Languages
{
    public interface ILanguageService
    {
        Task<List<LanguageModel>> GetAllLanguages(CancellationToken cancellationToken);
    }
}
