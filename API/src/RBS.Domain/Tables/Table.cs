using RBS.Domain.Reservations;
using RBS.Domain.Restaurants;
using RBS.Domain.TableImages;

namespace RBS.Domain.Tables
{
    public class Table : EntityBase
    {
        public int PersonCount { get; private set; }
        public ICollection<TableImage> Images { get; private set; }

        public Reservation Reservation { get; private set; }
        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
