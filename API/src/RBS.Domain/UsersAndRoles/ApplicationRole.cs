using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.UsersAndRoles
{
    public class ApplicationRole : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public virtual string Name { get; private set; }

        public ICollection<ApplicationUserRole>? UserRoles { get; private set; }
    }
}
