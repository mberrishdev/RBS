using RBS.Domain.RestaurantNotifications.Commands;

namespace RBS.Application.Services.RestaurantNotifications
{
    public interface IRestaurantNotificationService
    {
        Task CreateRestaurantNotification(CreateRestaurantNotificationCommand command);
    }
}
