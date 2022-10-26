using RBS.Application.Models.RestaurantModels;

namespace RBS.Application.Services.Restaurants
{
    public interface IRestaurantService
    {
        Task<RestaurantMainInformationModel> GetMainInformation(int id);
        Task<RestaruantModel> GetById(int id);
    }
}
