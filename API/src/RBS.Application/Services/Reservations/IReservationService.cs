using RBS.Application.Models.ReservationModels;
using RBS.Application.Services.Reservations.Responses;
using RBS.Domain.Reservations.Commands;

namespace RBS.Application.Services.Reservations
{
    public interface IReservationService
    {
        Task<ReservationResponse> ResevationCommandHandler(ReservationCommand command, CancellationToken cancellationToken);
        Task<List<ResravtionModel>> GetRestaurantReservationsByDay(int restaruantId, DateTime reseravtionDate, CancellationToken cancellationToken);
    }
}
