using RBS.Domain.Restaurants;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.RSTypes
{
    public class RSType : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }
        public bool IsMain { get; private set; }

        public Restaurant Restaurant { get; private set; }
    }
}
