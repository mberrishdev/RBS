using RBS.Domain.AdditionalInformations;
using RBS.Domain.Addresses;
using RBS.Domain.Enums;
using RBS.Domain.Images;
using RBS.Domain.Menus;
using RBS.Domain.Reservations;
using RBS.Domain.RestaurantNotifications;
using RBS.Domain.RestaurantPolicies;
using RBS.Domain.Reviews;
using RBS.Domain.RSTypes;
using RBS.Domain.Tables;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Restaurants
{
    public class Restaurant : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; private set; }
        [DataType(DataType.Time)]
        public DateTime OpentTime { get; private set; }
        [DataType(DataType.Time)]
        public DateTime CloseTime { get; private set; }
        [DataType(DataType.Time)]
        public DateTime PublishDate { get; private set; }
        public RestaurantStatus Status { get; private set; }
        [MaxLength(500)]
        public string GoogleMapUrl { get; private set; }
        public Address Address { get; private set; }
        public Menu Menus { get; private set; }
        public ICollection<AdditionalInformation> AdditionalInformations { get; private set; }
        public ICollection<Image> Images { get; private set; }
        public ICollection<Review> Reviews { get; private set; }
        public ICollection<RSType> RSTypes { get; private set; }
        public ICollection<Reservation> Reservations { get; private set; }
        public ICollection<Table> Tables { get; private set; }
        public ICollection<RestaurantNotification> RestaurantNotifications { get; private set; }
        public ICollection<RestaurantPolicy> RestaurantPolicies { get; private set; }
    }
}
