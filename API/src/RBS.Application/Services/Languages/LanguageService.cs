using RBS.Application.Models.Languages;
using RBS.Data;
using RBS.Data.Repositories;
using RBS.Domain.languages;
using System.Linq.Expressions;

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
            var languages = await _repository.GetListAsync(includeProperties: new Expression<Func<Language, object>>[1] { x => x.Country },
                orderBy: x => !x.IsDefault,
                orderByType: OrderByType.ASC);
            return languages.Select(x => new LanguageModel(x)).ToList();
        }
    }
}
