namespace RBS.Application.Models.TableImages
{
    public interface ITableImageService
    {
        Task<List<TableImageModel>> GetTableImages(int tableId);
        Task<TableImageModel> GetTable360Images(int tableId);
    }
}
