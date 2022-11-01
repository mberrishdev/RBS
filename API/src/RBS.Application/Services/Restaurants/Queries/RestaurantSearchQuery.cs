using RBS.Domain.Enums;

namespace RBS.Application.Services.Restaurants.Queries
{
    public class RestaurantSearchQuery : BaseQuery
    {
        public DateTime? Date { get; set; }
        public RestaurantOrderType OrderBy { get; set; }
    }
}
