namespace RBS.Application.Services.Auth.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
