using RBS.Domain.Reviews;

namespace RBS.Application.Models
{
    public class ReviewFullModel
    {
        public ReviewFullModel(ICollection<Review> reviews)
        {
            Reviews = reviews.Select(x => new ReviewModel(x)).ToList();
            OverallRate = Math.Round(reviews.Average(x => x.OverallRate).GetValueOrDefault(), 2);
            OverallFoodRate = Math.Round(reviews.Average(x => x.FoodRate).GetValueOrDefault(), 2);
            OverallServiceRate = Math.Round(reviews.Average(x => x.ServiceRate).GetValueOrDefault(), 2);
            OverallAmbienceRate = Math.Round(reviews.Average(x => x.AmbienceRate).GetValueOrDefault(), 2);
        }

        public List<ReviewModel> Reviews { get; set; }
        public decimal OverallRate { get; set; }
        public decimal OverallFoodRate { get; set; }
        public decimal OverallServiceRate { get; set; }
        public decimal OverallAmbienceRate { get; set; }

    }
}
