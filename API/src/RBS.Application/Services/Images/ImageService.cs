using RBS.Application.Models;
using RBS.Data.Repositories;
using RBS.Domain.Enums;
using RBS.Domain.Images;
using System.Linq.Expressions;

namespace RBS.Application.Services.Images
{
    public class ImageService : IImageService
    {
        private readonly IRepository<Image> _repository;

        public ImageService(IRepository<Image> repository)
        {
            _repository = repository;
        }

        public async Task<List<ImageModel>> GetRestaurantImages(int restaurantIid, int typeId)
        {
            var imageType = (ImageType)typeId;
            Expression<Func<Image, bool>> predicate = x => x.RestaurantId == restaurantIid && x.ImageType == imageType;
            if (imageType == ImageType.All)
                predicate = x => x.RestaurantId == restaurantIid;

            var images = await _repository.GetListAsync(predicate);
            images = images.OrderBy(x => x.OrderNumber).ToList();

            return images.Select(x => new ImageModel(x)).ToList();
        }

        public async Task<ImageModel> GetRestaurantTopImage(int restaurantId)
        {
            var image = await _repository.GetAsync(predicate: x => x.RestaurantId == restaurantId && x.IsTop == true);
            return new ImageModel(image);
        }
    }
}
