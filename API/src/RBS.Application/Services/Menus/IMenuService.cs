using RBS.Application.Models;

namespace RBS.Application.Services.Menus
{
    public interface IMenuService
    {
        Task<List<SubMenuTypeModel>> GetRestaurantSubMenyTypes(int restaurantId);
        Task<List<SubMenuModel>> GetMenuItemsBySubMenuId(int restaurantId, int subMenuId);
        Task<MenuModel> GetMenuFullData(int restaurantId, int subMenuId);
    }
}
