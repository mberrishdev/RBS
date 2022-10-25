namespace RBS.Application.Services.Auth.Models
{
    public class TokenRequest
    {
        public string Token { get; internal set; }
        public string RefreshToken { get; internal set; }
    }
}
