using RBS.Domain.Enums;
using System.Text.Json.Serialization;

namespace RBS.Domain.UsersAndRoles.Commands
{
    public class RegisterCommand
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int CountryId { get; set; }
        [JsonIgnore]
        public UserType UserType { get; set; }
    }
}
