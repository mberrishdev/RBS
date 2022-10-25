namespace RBS.Domain.UsersAndRoles.Commands
{
    public class GuestUserRegitrationCommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
