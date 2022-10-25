using RBS.Domain.Enums;
using RBS.Domain.ReservationReminders.Commands;
using RBS.Domain.Reservations;

namespace RBS.Domain.ReservationReminders
{
    public class ReservationRemainder : EntityBase
    {
        public NotificationType Type { get; private set; }
        public RemainderStatus Status { get; private set; }
        public DateTime ToBeSentDate { get; private set; }
        public DateTime? SendDate { get; private set; }
        public int ReservationId { get; private set; }
        public Reservation Reservation { get; private set; }

        public ReservationRemainder() { }

        public ReservationRemainder(CreateReservationRemainderCommand command)
        {
            Type = command.Type;
            Status = RemainderStatus.ToBeSent;
            ToBeSentDate = command.ToBeSentDate;
            ReservationId = command.ReservationId;
        }
    }
}
