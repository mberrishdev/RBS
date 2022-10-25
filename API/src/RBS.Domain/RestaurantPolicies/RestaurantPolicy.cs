using RBS.Domain.languages;
using RBS.Domain.Restaurants;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.RestaurantPolicies
{
    public class RestaurantPolicy : EntityBase
    {
        [Required]
        public string Title { get; private set; }
        [Required]
        public string Body { get; private set; }
        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
        [Required]
        public int LanguageId { get; private set; }
        public Language Language { get; private set; }
    }
}
