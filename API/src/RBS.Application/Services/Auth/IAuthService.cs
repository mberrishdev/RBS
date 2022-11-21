using RBS.Application.Services.Auth.Models;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(LoginCommand command, CancellationToken cancellationToken);
        Task<int> Register(RegisterCommand command, CancellationToken cancellationToken);
        Task<AuthResponse> RefreshToken(TokenRequest command, CancellationToken cancellationToken);
    }
}
