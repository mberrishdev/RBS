﻿using Microsoft.IdentityModel.Tokens;
using RBS.Application.Exceptions;
using RBS.Application.Services.Auth.Helper;
using RBS.Application.Services.Auth.Models;
using RBS.Application.Services.Settings.AuthSettings;
using RBS.Data.UnitOfWorks;
using RBS.Domain.RefreshTokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RBS.Application.Services.Auth.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly ITokenHelper _tokenHelper;
        private readonly IAuthSettings _authSettings;
        private readonly IUnitOfWork<RefreshToken> _unitOfWork;

        public TokenService(ITokenHelper tokenHelper, IAuthSettings authSettings, IUnitOfWork<RefreshToken> unitOfWork)
        {
            _tokenHelper = tokenHelper;
            _authSettings = authSettings;
            _unitOfWork = unitOfWork;
        }

        public async Task<AuthResponse> GenerateToken(UserInfoModel userInfo)
        {
            var claims = _tokenHelper.GetClaims(userInfo);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authSettings.SecretKey));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var jwt = new JwtSecurityToken(
                 issuer: _authSettings.ValidIssuer,
                 audience: _authSettings.ValidAudience,
                 notBefore: DateTime.Now,
                 claims: claims,
                 expires: DateTime.Now.AddMinutes(_authSettings.TokenExpirationMinutes),
                 signingCredentials: signInCred);

            var randomNumber = new byte[32];
            var refreshToken = new RefreshToken();

            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                refreshToken.JwtId = jwt.Id;
                refreshToken.Token = Convert.ToBase64String(randomNumber);
                refreshToken.UserId = userInfo.Id;
                refreshToken.CreateDate = DateTime.Now;
                refreshToken.ExpiryDate = DateTime.Now.AddMinutes(_authSettings.RefreshTokenExpirationMinutes);
            }

            await _unitOfWork.Repository.CreateAsync(refreshToken);
            await _unitOfWork.CommitAsync();

            return new AuthResponse
            {
                UserId = userInfo.Id,
                UserName = userInfo.UserName,
                Expires = DateTime.Now.AddMinutes(_authSettings.TokenExpirationMinutes),
                Token = new JwtSecurityTokenHandler().WriteToken(jwt),
                RefreshToken = refreshToken.Token,
                //UserRoles = userInfo.UserRoles.ToList()
            };
        }

        public async Task<AuthResponse> RefreshToken(TokenRequest tokenRequest)
        {
            var validatedToken = _tokenHelper.GetPrincipalFromToken(tokenRequest.Token);

            if (validatedToken == null)
            {
                throw new InvalidTokenException(tokenRequest.Token);
            }

            var storedRefreshToken = await _unitOfWork.Repository.GetAsync(predicate: x => x.Token == tokenRequest.RefreshToken);

            if (storedRefreshToken == null)
            {
                throw new InvalidTokenException(tokenRequest.RefreshToken);
            }

            if (DateTime.Now > storedRefreshToken.ExpiryDate)
            {
                throw new InvalidTokenException(tokenRequest.RefreshToken);
            }

            if (storedRefreshToken.Used)
            {
                throw new InvalidTokenException(tokenRequest.RefreshToken);
            }

            var jti = validatedToken.Claims.Single(x => x.Type == JwtRegisteredClaimNames.Jti).Value;

            if (storedRefreshToken.JwtId != jti)
            {
                throw new InvalidTokenException(tokenRequest.RefreshToken);
            }

            storedRefreshToken.Used = true;
            _unitOfWork.Repository.Update(storedRefreshToken);
            await _unitOfWork.CommitAsync();

            var userName = validatedToken.Claims.Single(x => x.Type == ClaimTypes.Name).Value;
            var userId = validatedToken.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value;
            //var userRoles = validatedToken.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();


            var userInfo = new UserInfoModel
            {
                Id = Convert.ToInt32(userId),
                UserName = userName,
                //UserRoles = userRoles
            };

            return await GenerateToken(userInfo);
        }
    }
}
