using RBS.Domain.PlatformNotifications.Commands;

namespace RBS.Application.Services.PlatformNotifications
{
    public interface IPlatformNotificationService
    {
        Task CreatePlatformNotification(CreatePlatformNotificationCommand command);
    }
}
