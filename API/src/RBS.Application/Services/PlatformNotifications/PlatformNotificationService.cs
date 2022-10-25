using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.PlatformNotifications;
using RBS.Domain.PlatformNotifications.Commands;

namespace RBS.Application.Services.PlatformNotifications
{
    public class PlatformNotificationService : IPlatformNotificationService
    {
        private readonly IUnitOfWork<PlatformNotification> _unitOfWork;
        private readonly IRepository<PlatformNotification> _repository;

        public PlatformNotificationService(IUnitOfWork<PlatformNotification> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
        }

        public async Task CreatePlatformNotification(CreatePlatformNotificationCommand command)
        {
            var platformNotificaton = new PlatformNotification(command);
            await _repository.CreateAsync(platformNotificaton);
            await _unitOfWork.CommitAsync();
        }
    }
}
