using RBS.Domain.SubMenus;

namespace RBS.Application.Models
{
    public class SubMenuModel
    {
        public int Id { get; set; }
        public string SubMenuType { get; set; }
        public List<SubMenuItemModel> Items { get; set; }

        public SubMenuModel(SubMenu subMenu)
        {
            Id = subMenu.Id;
            SubMenuType = subMenu.SubMenuType;
            Items = subMenu.Items.Select(x => new SubMenuItemModel(x)).ToList();
        }
    }

}
