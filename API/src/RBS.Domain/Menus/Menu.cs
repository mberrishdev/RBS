using RBS.Domain.Restaurants;
using RBS.Domain.SubMenus;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Menus
{
    public class Menu : EntityBase
    {
        [MaxLength(200)]
        public string? Description { get; private set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; private set; }

        public ICollection<SubMenu> SubMenus { get; private set; }

        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
