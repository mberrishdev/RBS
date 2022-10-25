using RBS.Domain.Restaurants;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Addresses
{
    public class Address : EntityBase
    {
        [Required]
        [MaxLength(30)]
        public string Country { get; private set; }
        [Required]
        [MaxLength(30)]
        public string City { get; private set; }
        [Required]
        [MaxLength(30)]
        public string Street { get; private set; }
        [MaxLength(30)]
        public string Number { get; private set; }

        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }

    }
}
