using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.RestaurantNotifications;
using RBS.Domain.RestaurantNotifications.Commands;

namespace RBS.Application.Services.RestaurantNotifications
{
    public class RestaurantNotificationService : IRestaurantNotificationService
    {
        private readonly IUnitOfWork<RestaurantNotification> _unitOfWork;
        private readonly IRepository<RestaurantNotification> _repository;

        public RestaurantNotificationService(IUnitOfWork<RestaurantNotification> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
        }

        public async Task CreateRestaurantNotification(CreateRestaurantNotificationCommand command)
        {
            var restaurantNotificaton = new RestaurantNotification(command);
            await _repository.CreateAsync(restaurantNotificaton);
            await _unitOfWork.CommitAsync();
        }
    }
}
