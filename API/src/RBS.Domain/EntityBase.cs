using System.ComponentModel.DataAnnotations;

namespace RBS.Domain
{
    public class EntityBase
    {
        [Required]
        [Key]
        public int Id { get; private set; }

        [DataType(DataType.Time)]
        public DateTime CreateDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime UpdateDate { get; set; }

        [MaxLength(100)]
        public string? ModifiedBy { get; set; }
        [MaxLength(100)]
        public string? CreatedBy { get; set; }
    }
}
