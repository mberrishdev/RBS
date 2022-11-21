using Common.Repository.Repository;
using RBS.Application.Models;
using RBS.Domain.Enums;
using RBS.Domain.Images;
using System.Linq.Expressions;

namespace RBS.Application.Services.Images
{
    public class ImageService : IImageService
    {
        private readonly IQueryRepository<Image> _queryRepository;

        public ImageService(IQueryRepository<Image> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<List<ImageModel>> GetRestaurantImages(int restaurantIid, int typeId, CancellationToken cancellationToken)
        {
            var imageType = (ImageType)typeId;
            Expression<Func<Image, bool>> predicate = x => x.RestaurantId == restaurantIid && x.ImageType == imageType;
            if (imageType == ImageType.All)
                predicate = x => x.RestaurantId == restaurantIid;

            var images = await _queryRepository.GetListAsync(predicate: predicate, cancellationToken: cancellationToken);
            images = images.OrderBy(x => x.OrderNumber).ToList();

            return images.Select(x => new ImageModel(x)).ToList();
        }

        public async Task<ImageModel> GetRestaurantTopImage(int restaurantId, CancellationToken cancellationToken)
        {
            var image = await _queryRepository.GetAsync(predicate: x => x.RestaurantId == restaurantId && x.IsTop == true, cancellationToken: cancellationToken);
            return new ImageModel(image);
        }
    }
}
