using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models.TableImages;
using RBS.Application.Models.TableMdels;
using RBS.Application.Services.Tables;

namespace RBS.API.Controllers.Table
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TableController : ApiControllerBase
    {
        private readonly ITableService _tableService;
        private readonly ITableImageService _tableImageService;

        public TableController(ITableService tableService, ITableImageService tableImageService)
        {
            _tableService = tableService;
            _tableImageService = tableImageService;
        }

        [HttpGet("GetTableByRestaurantId/{restaurantId}")]
        [ProducesResponseType(typeof(List<TableModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTableByRestaurantId([FromRoute] int restaurantId)
        {
            var result = await _tableService.GetTableByRestaurantId(restaurantId);
            return Ok(result);
        }

        [HttpGet("GetTableImages/{tableId}")]
        [ProducesResponseType(typeof(List<TableImageModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTableImages([FromRoute] int tableId)
        {
            var result = await _tableImageService.GetTableImages(tableId);
            return Ok(result);
        }

        [HttpGet("GetTable360Images/{tableId}")]
        [ProducesResponseType(typeof(List<TableImageModel>), StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTable360Images([FromRoute] int tableId)
        {
            var result = await _tableImageService.GetTable360Images(tableId);
            if (result == null)
                return Ok("360 image does not exist");
            return Ok(result);
        }
    }
}
