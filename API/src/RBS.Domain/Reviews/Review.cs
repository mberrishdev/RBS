using RBS.Domain.Restaurants;
using System.ComponentModel.DataAnnotations;

namespace RBS.Domain.Reviews
{
    public class Review : EntityBase
    {
        [MaxLength(200)]
        public string? Text { get; private set; }
        [MaxLength(50)]
        public string? ReviewerName { get; private set; }
        [MaxLength(50)]
        public string? ReviewerSurName { get; private set; }
        public decimal? OverallRate { get; private set; }
        public decimal? FoodRate { get; private set; }
        public decimal? ServiceRate { get; private set; }
        public decimal? AmbienceRate { get; private set; }
        [DataType(DataType.DateTime)]
        public DateTime? ReviewedDate { get; private set; }

        public int RestaurantId { get; private set; }
        public Restaurant Restaurant { get; private set; }
    }
}
