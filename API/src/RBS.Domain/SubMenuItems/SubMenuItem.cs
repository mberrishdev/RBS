using RBS.Domain.SubMenus;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.SubMenuItems
{
    public class SubMenuItem : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; private set; }
        [Required]
        [MaxLength(300)]
        public string Description { get; private set; }
        public string? Allergy { get; private set; }
        public decimal? Price { get; private set; }
        public string? Currency { get; private set; }
        public string? CurrencyIcon { get; private set; }
        public string? Src { get; private set; }
        public string? Alt { get; private set; }

        public int SubMenuId { get; private set; }
        public SubMenu SubMenu { get; private set; }

    }
}
