using Common.Repository.Repository;
using RBS.Domain.PlatformNotifications;
using RBS.Domain.PlatformNotifications.Commands;

namespace RBS.Application.Services.PlatformNotifications
{
    public class PlatformNotificationService : IPlatformNotificationService
    {
        private readonly IRepository<PlatformNotification> _repository;

        public PlatformNotificationService(IRepository<PlatformNotification> repository)
        {
            _repository = repository;
        }

        public async Task CreatePlatformNotification(CreatePlatformNotificationCommand command, CancellationToken cancellationToken)
        {
            var platformNotificaton = new PlatformNotification(command);
            await _repository.InsertAsync(platformNotificaton, cancellationToken);
        }
    }
}
