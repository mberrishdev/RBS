using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.UsersAndRoles
{
    public class ApplicationUserRole : EntityBase
    {
        [Required]
        public int UserId { get; private set; }
        [Required]
        public int RoleId { get; private set; }

        public ApplicationUser User { get; private set; }
        public virtual ApplicationRole Role { get; private set; }
    }
}
