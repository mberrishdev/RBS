using RBS.Domain.Menus;
using RBS.Domain.SubMenuItems;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.SubMenus
{
    public class SubMenu : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string SubMenuType { get; private set; }
        public ICollection<SubMenuItem> Items { get; private set; }

        public int MenuId { get; private set; }
        public Menu Menu { get; private set; }
    }
}
