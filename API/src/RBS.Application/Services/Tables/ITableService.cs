using RBS.Application.Models.TableMdels;

namespace RBS.Application.Services.Tables
{
    public interface ITableService
    {
        Task<TableModel> GetById(int tableId);
        Task<List<TableModel>> GetTableByRestaurantId(int restaurantId);
    }
}
