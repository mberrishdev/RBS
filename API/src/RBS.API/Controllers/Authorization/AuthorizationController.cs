using Microsoft.AspNetCore.Mvc;
using RBS.Application.Services.Auth;
using RBS.Application.Services.Auth.Models;
using RBS.Domain.UsersAndRoles.Commands;

namespace RBS.API.Controllers.Authorization
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthorizationController : ApiControllerBase
    {
        private readonly IAuthService _authService;

        public AuthorizationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
        {
            var result = await _authService.Login(command, cancellationToken);
            return Ok(result);
        }

        [HttpPost("Register")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<ActionResult<int>> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            var id = await _authService.Register(command, cancellationToken);
            return Ok(id);
        }

        [HttpPost("RefreshToken")]
        [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponse>> RefreshToken([FromBody] TokenRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.RefreshToken(request, cancellationToken);
            return Ok(result);
        }
    }
}
