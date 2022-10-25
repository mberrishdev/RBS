using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.ReservationReminders;
using RBS.Domain.ReservationReminders.Commands;

namespace RBS.Application.Services.ReservationRemainders
{
    public class ReservationRemainderService : IReservationRemainderService
    {
        private readonly IUnitOfWork<ReservationRemainder> _unitOfWork;
        private readonly IRepository<ReservationRemainder> _repository;

        public ReservationRemainderService(IUnitOfWork<ReservationRemainder> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
        }

        public async Task CreateReservationRemainder(CreateReservationRemainderCommand command)
        {
            var reservationRemainder = new ReservationRemainder(command);
            await _repository.CreateAsync(reservationRemainder);
            await _unitOfWork.CommitAsync();
        }
    }
}
