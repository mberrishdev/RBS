using System.ComponentModel.DataAnnotations;

namespace RBS.Domain
{
    public class EntityBase
    {
        [Required]
        [Key]
        public int Id { get; private set; }
    }
}
