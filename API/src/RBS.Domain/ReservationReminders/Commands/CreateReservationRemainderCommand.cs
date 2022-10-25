using RBS.Domain.Enums;

namespace RBS.Domain.ReservationReminders.Commands
{
    public class CreateReservationRemainderCommand
    {
        public NotificationType Type { get; set; }
        public DateTime ToBeSentDate { get; set; }
        public int ReservationId { get; set; }
    }
}
