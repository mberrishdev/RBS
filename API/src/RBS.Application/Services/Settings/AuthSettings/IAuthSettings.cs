namespace RBS.Application.Services.Settings.AuthSettings
{
    public interface IAuthSettings
    {
        string SecretKey { get; set; }
        int TokenExpirationMinutes { get; set; }
        int RefreshTokenExpirationMinutes { get; set; }
        string ValidIssuer { get; }
        string ValidAudience { get; }
    }
}
