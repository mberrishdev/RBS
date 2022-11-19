using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models;
using RBS.Application.Services.Menus;

namespace RBS.API.Controllers.Menu
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class MenuController : ApiControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenuTypes/{restaurantId}")]
        [ProducesResponseType(typeof(List<SubMenuTypeModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SubMenuTypeModel>>> GetMenuTypes([FromRoute] int restaurantId)
        {
            var result = await _menuService.GetRestaurantSubMenyTypes(restaurantId);
            return Ok(result);
        }

        [HttpGet("GetMenuItemsBySubMenuId/{restaurantId}/{subMenuId}")]
        [ProducesResponseType(typeof(List<SubMenuModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<SubMenuModel>>> GetMenuItemsBySubMenuId([FromRoute] int restaurantId, [FromRoute] int subMenuId)
        {
            var result = await _menuService.GetMenuItemsBySubMenuId(restaurantId, subMenuId);
            return Ok(result);
        }

        [HttpGet("GetMenuByRestaurantId/{restaurantId}")]
        [ProducesResponseType(typeof(MenuModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<MenuModel>> GetMenuByRestaurantId([FromRoute] int restaurantId)
        {
            var result = await _menuService.GetMenuByRestaurantId(restaurantId);
            return Ok(result);
        }


    }
}
