using Common.Repository.Repository;
using RBS.Domain.ReservationReminders;
using RBS.Domain.ReservationReminders.Commands;

namespace RBS.Application.Services.ReservationRemainders
{
    public class ReservationRemainderService : IReservationRemainderService
    {
        private readonly IRepository<ReservationRemainder> _repository;

        public ReservationRemainderService(IRepository<ReservationRemainder> repository)
        {
            _repository = repository;
        }

        public async Task CreateReservationRemainder(CreateReservationRemainderCommand command, CancellationToken cancellationToken)
        {
            var reservationRemainder = new ReservationRemainder(command);
            await _repository.InsertAsync(reservationRemainder, cancellationToken);
        }
    }
}
