using RBS.Application.Services.Auth.Models;

namespace RBS.Application.Services.Auth.TokenService
{
    public interface ITokenService
    {
        Task<AuthResponse> GenerateToken(UserInfoModel userInfo, CancellationToken cancellationToken);
        Task<AuthResponse> RefreshToken(TokenRequest tokenRequest, CancellationToken cancellationToken);
    }
}
