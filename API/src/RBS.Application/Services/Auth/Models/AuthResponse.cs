namespace RBS.Application.Services.Auth.Models
{
    public class AuthResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public DateTime Expires { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        //public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
