using RBS.Domain.Common;
using RBS.Domain.Enums;

namespace RBS.Domain.RestaurantNotifications.Commands
{
    public class CreateRestaurantNotificationCommand : BaseCommand
    {
        public int UserId { get; set; }
        public int RestaruantId { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
