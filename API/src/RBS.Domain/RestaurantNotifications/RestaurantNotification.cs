using RBS.Domain.Enums;
using RBS.Domain.RestaurantNotifications.Commands;
using RBS.Domain.Restaurants;
using RBS.Domain.UsersAndRoles;

namespace RBS.Domain.RestaurantNotifications
{
    public class RestaurantNotification : EntityBase
    {
        public NotificationType NotificationType { get; private set; }
        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
        public int ApplicationUserId { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }

        private RestaurantNotification() { }
        public RestaurantNotification(CreateRestaurantNotificationCommand command)
        {
            NotificationType = command.NotificationType;
            RestaurantId = command.RestaruantId;
            ApplicationUserId = command.UserId;
        }
    }
}
