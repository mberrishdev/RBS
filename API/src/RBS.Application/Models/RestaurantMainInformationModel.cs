using RBS.Domain.Restaurants;

namespace RBS.Application.Models
{
    public class RestaurantMainInformationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ReviewerCount { get; set; }
        public decimal? AverageRate { get; set; }
        public string? MainType { get; set; }

        public AddressModel Address { get; set; }

        public RestaurantMainInformationModel(Restaurant restaurant)
        {
            Id = restaurant.Id;
            Name = restaurant.Name;
            Description = restaurant.Description;
            ReviewerCount = restaurant.Reviews?.Count;
            AverageRate = restaurant.Reviews?.Average(x => x.OverallRate).GetValueOrDefault();
            MainType = restaurant.RSTypes?.FirstOrDefault(x => x.IsMain)?.Name;
            Address = new AddressModel(restaurant.Address);
        }

    }
}
