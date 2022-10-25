using RBS.Application.Services.Auth.Models;
using System.Security.Claims;

namespace RBS.Application.Services.Auth.Helper
{
    public interface ITokenHelper
    {
        List<Claim> GetClaims(UserInfoModel userInfo);
        ClaimsPrincipal GetPrincipalFromToken(string token);
    }
}
