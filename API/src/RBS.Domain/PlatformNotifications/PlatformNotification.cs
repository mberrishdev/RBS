using RBS.Domain.Enums;
using RBS.Domain.PlatformNotifications.Commands;
using RBS.Domain.UsersAndRoles;

namespace RBS.Domain.PlatformNotifications
{
    public class PlatformNotification : EntityBase
    {

        public NotificationType NotificationType { get; private set; }
        public int ApplicationUserId { get; private set; }
        public ApplicationUser ApplicationUser { get; private set; }
        private PlatformNotification() { }
        public PlatformNotification(CreatePlatformNotificationCommand command)
        {
            NotificationType = command.NotificationType;
            ApplicationUserId = command.UserId;
        }
    }
}
