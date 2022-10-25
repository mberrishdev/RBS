using RBS.Domain.Enums;
using RBS.Domain.PlatformNotifications;
using RBS.Domain.Reservations;
using RBS.Domain.RestaurantNotifications;
using RBS.Domain.UsersAndRoles.Commands;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.UsersAndRoles
{
    public class ApplicationUser : EntityBase
    {
        [Required]
        public string UserName { get; private set; }
        [Required]
        [MaxLength(50)]
        public string Email { get; private set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; private set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; private set; }
        [Required]
        public UserType UserType { get; private set; }
        public string? PasswordHash { get; private set; }
        [Required]
        public string PhoneNumber { get; private set; }
        [Required]
        public int CountyId { get; private set; }

        public ICollection<ApplicationUserRole>? UserRoles { get; private set; }
        public ICollection<Reservation> Reservation { get; private set; }
        public ICollection<RestaurantNotification> RestaurantNotifications { get; private set; }
        public PlatformNotification PlatformNotification { get; private set; }
        //public int CountryId { get; private set; }
        //public Country Country { get; private set; }

        private ApplicationUser() { }

        public ApplicationUser(RegisterCommand command)
        {
            Email = command.Email;
            UserName = command.Username;
            FirstName = command.FirstName;
            LastName = command.LastName;
            PasswordHash = command.Password;
            PhoneNumber = command.PhoneNumber;
            CountyId = command.CountryId;
            UserType = command.UserType;
        }

        public ApplicationUser(GuestUserRegitrationCommand command)
        {
            Email = command.Email;
            //ToBeUniq
            UserName = command.FirstName + command.LastName;
            FirstName = command.FirstName;
            LastName = command.LastName;
            PhoneNumber = command.PhoneNumber;
            CountyId = command.CountryId;
            UserType = UserType.GuestUser;
        }
    }
}