using RBS.Domain.Countries;
using RBS.Domain.PrivacyPolicies;
using RBS.Domain.RestaurantPolicies;
using RBS.Domain.TermsAndConditions;
using RBS.Domain.TextContents;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.languages
{
    public class Language : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(5)]
        public string Key { get; set; }
        public int CountryId { get; set; }
        public bool IsDefault { get; set; }

        public ICollection<Caption> Captions { get; private set; }
        public ICollection<TermAndCondition> TermsAndConditions { get; private set; }
        public ICollection<PrivacyPolicy> PrivacyPolicies { get; private set; }
        public ICollection<RestaurantPolicy> RestaurantPolicies { get; private set; }
        public Country Country { get; private set; }
    }
}
