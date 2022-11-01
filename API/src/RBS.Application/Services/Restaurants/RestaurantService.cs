using RBS.Application.Helper;
using RBS.Application.Models.RestaurantModels;
using RBS.Application.Services.Restaurants.Queries;
using RBS.Data;
using RBS.Data.Repositories;
using RBS.Data.UnitOfWorks;
using RBS.Domain.Enums;
using RBS.Domain.Restaurants;
using System.Linq.Expressions;

namespace RBS.Application.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork<Restaurant> _unitOfWork;
        private readonly IRepository<Restaurant> _repository;
        //private readonly IReservationService _reservationService;
        //TODO:ADD CONTACT INFO
        public RestaurantService(IUnitOfWork<Restaurant> unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.Repository;
            //_reservationService = reservationService;
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

        public async Task<List<RestaruantSearchModel>> Search(RestaurantSearchQuery query)
        {
            (Expression<Func<Restaurant, object>>? Expression, OrderByType OrderType) orderBy = query.OrderBy switch
            {
                RestaurantOrderType.None => (null, OrderByType.None),
                RestaurantOrderType.Newest => (x => x.PublishDate, OrderByType.DESC),
                RestaurantOrderType.Featured => (null, OrderByType.None),
                RestaurantOrderType.Nearest => (null, OrderByType.None),
                RestaurantOrderType.HigestRated => (x => x.Reviews.Average(x => x.OverallRate), OrderByType.DESC),
                _ => (null, OrderByType.None),
            };


            var restaurants = await _repository.GetListAsync(
                includeProperties: new Expression<Func<Restaurant, object>>[4] { x => x.Address, x => x.Reviews, x => x.Images, x => x.RSTypes },
                orderBy: orderBy.Expression, orderByType: orderBy.OrderType);

            if (query.OrderBy == RestaurantOrderType.Nearest)
                restaurants = restaurants.OrderBy(x => DistanceHelper.DistanceTo(query.UserModel.IpInfo.Latitude, query.UserModel.IpInfo.Longitude,
                                            x.Address.Latitude, x.Address.Longitude, 'K')).ToList();


            //ამოვიღოთ ისეთი რომლებიც არ არის დაჯავშნილი - TODO
            //var result = restaurants.Select(x => new RestaruantSearchModel(x)).ToList();
            //foreach (var restaurantSearchModel in result)
            //{
            //    var reservation = await _reservationService.GetRestaurantReservationsByDay(restaurantSearchModel.Id, query.Date ?? DateTime.Now);
            //}
            return restaurants.Select(x => new RestaruantSearchModel(x)).ToList();
        }
    }
}
