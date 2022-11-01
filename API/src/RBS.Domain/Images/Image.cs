using RBS.Domain.Enums;
using RBS.Domain.Restaurants;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Images
{
    public class Image : EntityBase
    {
        [Required]
        [MaxLength(500)]
        public string Src { get; private set; }
        [Required]
        [MaxLength(30)]
        public string Alt { get; private set; }
        public bool IsMain { get; private set; }
        public bool IsTop { get; private set; }
        public ImageType ImageType { get; private set; }
        [DefaultValue("0")]
        public int OrderNumber { get; private set; }

        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
