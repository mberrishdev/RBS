using RBS.Application.Services.Auth.Models;

namespace RBS.Application.Services.Auth.TokenService
{
    public interface ITokenService
    {
        Task<AuthResponse> GenerateToken(UserInfoModel userInfo);
        Task<AuthResponse> RefreshToken(TokenRequest tokenRequest);
    }
}
