using RBS.Domain.ReservationReminders.Commands;

namespace RBS.Application.Services.ReservationRemainders
{
    public interface IReservationRemainderService
    {
        Task CreateReservationRemainder(CreateReservationRemainderCommand command, CancellationToken cancellationToken);
    }
}
