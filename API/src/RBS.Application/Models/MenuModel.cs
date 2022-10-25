using RBS.Domain.Menus;

namespace RBS.Application.Models
{
    public class MenuModel
    {
        public int Id { get; set; }
        public List<SubMenuModel> SubMenus { get; set; }
        public DateTime UpdateDate { get; set; }

        public MenuModel(Menu menu)
        {
            Id = menu.Id;
            SubMenus = menu.SubMenus.Select(x => new SubMenuModel(x)).ToList();
            UpdateDate = menu.UpdateDate;
        }
    }
}
