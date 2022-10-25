using RBS.Domain.languages;

namespace RBS.Application.Models.Languages
{
    public class LanguageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public bool IsDefault { get; set; }
        public CountryModel Country { get; set; }

        public LanguageModel(Language language)
        {
            Id = language.Id;
            Name = language.Name;
            CountryId = language.CountryId;
            IsDefault = language.IsDefault;
            if (language.Country != null)
                Country = new CountryModel(language.Country);
        }
    }
}
