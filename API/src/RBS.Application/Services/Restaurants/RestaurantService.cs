using RBS.Application.Models;
using RBS.Application.Models.RestaurantModels;
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.Restaurants;
using System.Linq.Expressions;

namespace RBS.Application.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork<Restaurant> _unitOfWork;
        private readonly IRepository<Restaurant> _repository;
        //TODO:ADD CONTACT INFO
        public RestaurantService(IUnitOfWork<Restaurant> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
        }

        public async Task<RestaurantMainInformationModel> GetMainInformation(int id)
        {
            var restaurant = await _repository.GetAsync(predicate: x => x.Id == id,
                includeProperties: new Expression<Func<Restaurant, object>>[3] { x => x.Address, x => x.Reviews, x => x.RSTypes });

            var result = new RestaurantMainInformationModel(restaurant);


            return result;
        }

        public async Task<RestaruantModel> GetById(int id)
        {
            var restaurant = await _repository.GetAsync(predicate: x => x.Id == id);
            if (restaurant == null)
                return null;

            return new RestaruantModel(restaurant);
        }

    }
}
