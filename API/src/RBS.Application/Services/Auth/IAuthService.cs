using RBS.Application.Services.Auth.Models;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginCommand command);
        Task<int> Register(RegisterCommand command);
        Task<AuthResponse> RefreshToken(TokenRequest command);
    }
}
