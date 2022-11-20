using Common.Lists.Sorting;
using Common.Repository.Repository;
using RBS.Application.Models.Languages;
using RBS.Domain.languages;
using System.Linq.Expressions;

namespace RBS.Application.Services.Languages
{
    public class LanguageService : ILanguageService
    {
        private readonly IQueryRepository<Language> _queryRepository;

        public LanguageService(IQueryRepository<Language> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<LanguageModel>> GetAllLanguages(CancellationToken cancellationToken)
        {
            var relatedProperties = new Expression<Func<Language, object>>[1] { x => x.Country };
            var sortingDetails = new SortingDetails<Language>(new SortItem<Language>(x => x.IsDefault, SortDirection.ASC));

            var languages = await _queryRepository.GetListAsync(relatedProperties: relatedProperties,
                sortingDetails: sortingDetails, cancellationToken: cancellationToken);

            return languages.Select(x => new LanguageModel(x)).ToList();
        }
    }
}
