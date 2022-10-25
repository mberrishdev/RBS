using RBS.Application.Services.Reservations.Responses;
using RBS.Domain.Reservations.Commands;

namespace RBS.Application.Services.Reservations
{
    public interface IReservationService
    {
        Task<ReservationResponse> ResevationCommandHandler(ReservationCommand command);
    }
}
