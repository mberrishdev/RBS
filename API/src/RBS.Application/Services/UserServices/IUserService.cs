using RBS.Domain.UsersAndRoles;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<int> CreateAsync(RegisterCommand command, CancellationToken cancellationToken);
        Task<ApplicationUser> FindByName(string username, CancellationToken cancellationToken);
        bool CheckPassword(ApplicationUser user, string password);
        Task UpdateUser(ApplicationUser user, CancellationToken cancellationToken);
        Task<int> RegisterGuestUser(GuestUserRegitrationCommand command, CancellationToken cancellationToken);
    }
}
