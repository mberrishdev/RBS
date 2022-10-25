using RBS.Domain.UsersAndRoles;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.UserServices
{
    public interface IUserService
    {
        Task<int> CreateAsync(RegisterCommand command);
        Task<ApplicationUser> FindByName(string username);
        bool CheckPassword(ApplicationUser user, string password);
        Task UpdateUser(ApplicationUser user);
        Task<int> RegisterGuestUser(GuestUserRegitrationCommand command);
    }
}
