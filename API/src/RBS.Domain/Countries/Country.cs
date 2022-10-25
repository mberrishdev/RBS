using RBS.Domain.languages;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Countries
{
    public class Country : EntityBase
    {
        [Required]
        public string Code { get; private set; }
        [Required]
        public string Name { get; private set; }
        [Required]
        public string DiallingCode { get; private set; }
        [Required]
        public string FlagSrc { get; private set; }

        public Language Language { get; private set; }

        //public ICollection<ApplicationUser> ApplicationUsers { get; private set; }
    }
}
