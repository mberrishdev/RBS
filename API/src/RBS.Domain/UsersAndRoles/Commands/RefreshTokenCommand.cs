namespace RBS.Domain.UsersAndRoles.Commands
{
    public class RefreshTokenCommand
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
