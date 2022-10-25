using RBS.Application.Models.Languages;
using RBS.Data.Repositories;
using RBS.Domain.languages;

namespace RBS.Application.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _repository;

        public LanguageService(IRepository<Language> repository)
        {
            _repository = repository;
        }

        public async Task<List<LanguageModel>> GetAllLanguages()
        {
            var languages = await _repository.GetAllAsyncWithIP(x => x.Country);
            return languages.Select(x => new LanguageModel(x)).OrderBy(x => !x.IsDefault).ToList();
        }
    }
}
