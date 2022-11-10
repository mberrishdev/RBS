namespace RBS.Application.Models.TableImages
{
    public interface ITableImageService
    {
        Task<List<TableImageModel>> GetTableImages(int tableId);
    }
}
