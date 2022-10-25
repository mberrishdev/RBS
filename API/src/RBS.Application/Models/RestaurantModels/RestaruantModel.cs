using RBS.Domain.Restaurants;

namespace RBS.Application.Models.RestaurantModels
{
    public class RestaruantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OpentTime { get; set; }
        public DateTime CloseTime { get; set; }


        public RestaruantModel(Restaurant restaruant)
        {
            Id = restaruant.Id;
            Name = restaruant.Name;
            Description = restaruant.Description;
            OpentTime = restaruant.OpentTime;
            CloseTime = restaruant.CloseTime;
        }
    }
}
