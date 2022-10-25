using RBS.Domain.Common;
using RBS.Domain.Enums;

namespace RBS.Domain.PlatformNotifications.Commands
{
    public class CreatePlatformNotificationCommand : BaseCommand
    {
        public int UserId { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
