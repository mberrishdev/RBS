namespace RBS.Application.Services.Settings.AuthSettings
{
    public class AuthSettings : IAuthSettings
    {
        public string SecretKey { get; set; }
        public int TokenExpirationMinutes { get; set; }
        public int RefreshTokenExpirationMinutes { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
    }
}
