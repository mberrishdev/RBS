using RBS.Domain.ReservationReminders;
using RBS.Domain.Reservations.Commands;
using RBS.Domain.Restaurants;
using RBS.Domain.Tables;
using RBS.Domain.UsersAndRoles;

namespace RBS.Domain.Reservations
{
    public class Reservation : EntityBase
    {
        public DateTime DateTime { get; private set; }
        public int PersonCount { get; private set; }
        public string? SpecialRequest { get; private set; }
        public string QrCode { get; private set; }

        public int? TableId { get; private set; }
        public Table? Table { get; private set; }

        public int ApplicationUserId { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }

        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }

        public ReservationRemainder ReservationReminder { get; private set; }

        public Reservation() { }

        public Reservation(ReservationCommand command)
        {
            DateTime = command.DateTime;
            PersonCount = command.PersonCount;
            SpecialRequest = command.SpecialRequest;
            TableId = command.TableId;
            ApplicationUserId = command.UserModel.UserId;
            RestaurantId = command.RestaurantId;
        }

        public void AddQrCode(byte[] qrCode)
        {
            QrCode = qrCode.ToString();
        }
    }
}



//public class ReservationCommand
//{
//    public int? OccasionId { get; set; }
//    public string? SpecialRequest { get; set; }
//    public bool IsUserLogIn { get; set; }
//    public GuestUserRestrationCommand? GuestUser { get; set; }
//    public bool SendNewsOfRestaurant { get; set; }
//    public bool SendNewsOfPlatform { get; set; }
//    public bool SendReservationReminders { get; set; }
//    public bool AddBookingToCallendar { get; set; }

//}