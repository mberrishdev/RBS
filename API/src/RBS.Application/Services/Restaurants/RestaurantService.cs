using Common.Lists.Sorting;
using Common.Repository.Repository;
using RBS.Application.Helper;
using RBS.Application.Models.RestaurantModels;
using RBS.Application.Services.Restaurants.Queries;
using RBS.Domain.Enums;
using RBS.Domain.Restaurants;
using System.Linq.Expressions;

namespace RBS.Application.Services.Restaurants
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IQueryRepository<Restaurant> _queryRepository;

        public RestaurantService(IQueryRepository<Restaurant> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        //private readonly IReservationService _reservationService;
        //TODO:ADD CONTACT INFO

        public async Task<RestaurantMainInformationModel> GetMainInformation(int id, CancellationToken cancellationToken)
        {
            var restaurant = await _queryRepository.GetAsync(predicate: x => x.Id == id,
                relatedProperties: new Expression<Func<Restaurant, object>>[3] { x => x.Address, x => x.Reviews, x => x.RSTypes },
                cancellationToken: cancellationToken);

            var result = new RestaurantMainInformationModel(restaurant);


            return result;
        }

        public async Task<RestaruantModel> GetById(int id, CancellationToken cancellationToken)
        {
            var restaurant = await _queryRepository.GetAsync(predicate: x => x.Id == id, cancellationToken: cancellationToken);
            if (restaurant == null)
                return null;

            return new RestaruantModel(restaurant);
        }

        public async Task<List<RestaruantSearchModel>> Search(RestaurantSearchQuery query, CancellationToken cancellationToken)
        {
            //TODO add feature and nearest
            var sortingDetails = query.OrderBy switch
            {
                RestaurantOrderType.None => new SortingDetails<Restaurant>(new SortItem<Restaurant>(x => x.Id, SortDirection.DESC)),
                RestaurantOrderType.Newest => new SortingDetails<Restaurant>(new SortItem<Restaurant>(x => x.PublishDate, SortDirection.DESC)),
                RestaurantOrderType.Featured => new SortingDetails<Restaurant>(new SortItem<Restaurant>(x => x.Id, SortDirection.DESC)),
                RestaurantOrderType.Nearest => new SortingDetails<Restaurant>(new SortItem<Restaurant>(x => x.Id, SortDirection.DESC)),
                RestaurantOrderType.HigestRated => new SortingDetails<Restaurant>(new SortItem<Restaurant>(x => x.Reviews.Average(x => x.OverallRate), SortDirection.DESC)),
                _ => new SortingDetails<Restaurant>(new SortItem<Restaurant>(x => x.Id, SortDirection.DESC)),
            };

            var relatedProperties = new Expression<Func<Restaurant, object>>[4] { x => x.Address, x => x.Reviews, x => x.Images, x => x.RSTypes };

            var restaurants = await _queryRepository.GetListAsync(
                relatedProperties: relatedProperties,
                sortingDetails: sortingDetails,
                cancellationToken: cancellationToken);

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
