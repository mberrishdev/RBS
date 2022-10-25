using RBS.Domain.SubMenus;

namespace RBS.Application.Models
{
    public class SubMenuTypeModel
    {
        public int SubMenuId { get; set; }
        public string Type { get; set; }

        public SubMenuTypeModel(SubMenu subMenu)
        {
            SubMenuId = subMenu.Id;
            Type = subMenu.SubMenuType;
        }
    }
}
