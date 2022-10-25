using RBS.Domain.languages;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.TermsAndConditions
{
    public class TermAndCondition : EntityBase
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Body { get; private set; }
        [Required]
        public int LanguageId { get; private set; }
        public Language Language { get; private set; }
    }
}
