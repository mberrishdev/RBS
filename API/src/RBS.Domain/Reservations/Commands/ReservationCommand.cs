using RBS.Domain.Common;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Domain.Reservations.Commands
{
    public class ReservationCommand : BaseCommand
    {
        public int RestaurantId { get; set; }
        public DateTime DateTime { get; set; }
        public int PersonCount { get; set; }
        public int TableId { get; set; }
        public int? OccasionId { get; set; }
        public string? SpecialRequest { get; set; }
        public bool IsUserLogIn { get; set; }
        public GuestUserRegitrationCommand? GuestUser { get; set; }
        public bool SendNewsOfRestaurant { get; set; }
        public bool SendNewsOfPlatform { get; set; }
        public bool SendReservationReminders { get; set; }
        public bool AddBookingToCallendar { get; set; }
    }
}
