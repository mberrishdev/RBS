using RBS.Domain.languages;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.TextContents
{
    public class Caption : EntityBase
    {
        [Required]
        [MaxLength(200)]
        public string Key { get; private set; }
        [Required]
        [MaxLength(500)]
        public string Value { get; private set; }
        [Required]
        public int LanguageId { get; private set; }
        public Language Language { get; private set; }
    }
}
