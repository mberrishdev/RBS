using Common.Repository.Repository;
using RBS.Domain.RestaurantNotifications;
using RBS.Domain.RestaurantNotifications.Commands;

namespace RBS.Application.Services.RestaurantNotifications
{
    public class RestaurantNotificationService : IRestaurantNotificationService
    {
        private readonly IRepository<RestaurantNotification> _repository;

        public RestaurantNotificationService(IRepository<RestaurantNotification> repository)
        {
            _repository = repository;
        }

        public async Task CreateRestaurantNotification(CreateRestaurantNotificationCommand command, CancellationToken cancellationToken)
        {
            var restaurantNotificaton = new RestaurantNotification(command);
            await _repository.InsertAsync(restaurantNotificaton, cancellationToken);
        }
    }
}
