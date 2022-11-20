using RBS.Application.Models.RestaurantModels;
using RBS.Application.Services.Restaurants.Queries;

namespace RBS.Application.Services.Restaurants
{
    public interface IRestaurantService
    {
        Task<RestaurantMainInformationModel> GetMainInformation(int id, CancellationToken cancellationToken);
        Task<RestaruantModel> GetById(int id, CancellationToken cancellationToken);
        Task<List<RestaruantSearchModel>> Search(RestaurantSearchQuery query, CancellationToken cancellationToken);
    }
}
