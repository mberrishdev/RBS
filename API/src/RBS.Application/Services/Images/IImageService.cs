using RBS.Application.Models;

namespace RBS.Application.Services.Images
{
    public interface IImageService
    {
        Task<List<ImageModel>> GetRestaurantImages(int restaurantIid, int typeId, CancellationToken cancellationToken);
        Task<ImageModel> GetRestaurantTopImage(int restaurantId, CancellationToken cancellationToken);
    }
}
