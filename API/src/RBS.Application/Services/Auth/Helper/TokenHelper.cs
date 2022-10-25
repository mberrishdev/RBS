using Microsoft.IdentityModel.Tokens;
using RBS.Application.Exceptions;
using RBS.Application.Services.Auth.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RBS.Application.Services.Auth.Helper
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenValidationParameters _tokenValidationParameters;

        public TokenHelper(TokenValidationParameters tokenValidationParameters)
        {
            _tokenValidationParameters = tokenValidationParameters;
        }

        public List<Claim> GetClaims(UserInfoModel userInfo)
        {
            var claims = new Claim[]
                 {
                    new Claim(ClaimTypes.Name, userInfo.UserName),
                    new Claim(ClaimTypes.NameIdentifier, userInfo.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };

            var newClaim = claims.ToList();

            //foreach (var role in userInfo.UserRoles)
            //{
            //    newClaim.Add(new Claim(ClaimTypes.Role, role));
            //}

            return newClaim;
        }

        public ClaimsPrincipal GetPrincipalFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParameters = _tokenValidationParameters.Clone();
                tokenValidationParameters.ValidateLifetime = false;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principal;
            }
            catch (Exception)
            {
                throw new InvalidTokenException(token);
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature,
                       StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
