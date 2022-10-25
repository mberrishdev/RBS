using RBS.Application.Exceptions;
using RBS.Application.Services.Auth.Models;
using RBS.Application.Services.Auth.TokenService;
using RBS.Application.Services.UserServices;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthService(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Login(LoginCommand command)
        {
            var user = await _userService.FindByName(command.Username);
            if (user != null && _userService.CheckPassword(user, command.Password))
            {
                //var userRoles = await _userService.GetRolesAsync(user.Id.ToString());

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var userInfoModel = new UserInfoModel()
                {
                    Id = user.Id,
                    UserName = user.UserName,
                };

                return await _tokenService.GenerateToken(userInfoModel);
            }
            return null;
        }

        public async Task<int> Register(RegisterCommand command)
        {
            var userExists = await _userService.FindByName(command.Username);
            if (userExists != null)
                throw new AuthException("User already exists!");

            var id = await _userService.CreateAsync(command);

            if (id <= 0)
                throw new AuthException("User creation failed! Please check user details and try again.");

            return id;
        }

        public async Task<AuthResponse> RefreshToken(TokenRequest tokenRequest)
        {
            return await _tokenService.RefreshToken(tokenRequest);
        }
    }
}
