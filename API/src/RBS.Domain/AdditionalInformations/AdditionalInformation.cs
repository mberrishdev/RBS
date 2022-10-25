using RBS.Domain.Restaurants;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.AdditionalInformations
{
    public class AdditionalInformation : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Key { get; private set; }
        [MaxLength(500)]
        public string Value { get; private set; }
        [MaxLength(100)]
        public string Icon { get; private set; }
        public bool IsUrl { get; private set; }

        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
