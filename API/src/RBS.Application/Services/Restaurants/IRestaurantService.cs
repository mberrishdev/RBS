using RBS.Application.Models.RestaurantModels;
using RBS.Application.Services.Restaurants.Queries;

namespace RBS.Application.Services.Restaurants
{
    public interface IRestaurantService
    {
        Task<RestaurantMainInformationModel> GetMainInformation(int id);
        Task<RestaruantModel> GetById(int id);
        Task<List<RestaruantSearchModel>> Search(RestaurantSearchQuery query);
    }
}
