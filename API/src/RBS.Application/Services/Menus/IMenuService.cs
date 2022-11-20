using RBS.Application.Models;

namespace RBS.Application.Services.Menus
{
    public interface IMenuService
    {
        Task<List<SubMenuTypeModel>> GetRestaurantSubMenyTypes(int restaurantId, CancellationToken cancellationToken);
        Task<List<SubMenuModel>> GetMenuItemsBySubMenuId(int restaurantId, int subMenuId, CancellationToken cancellationToken);
        Task<MenuModel> GetMenuByRestaurantId(int restaurantId, CancellationToken cancellationToken);
    }
}
