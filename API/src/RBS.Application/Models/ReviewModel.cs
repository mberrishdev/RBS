using RBS.Domain.Reviews;

namespace RBS.Application.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public string? ReviewerName { get; set; }
        public string? ReviewerSurName { get; set; }
        public decimal? OverallRate { get; set; }
        public decimal? FoodRate { get; set; }
        public decimal? ServiceRate { get; set; }
        public decimal? AmbienceRate { get; set; }
        public DateTime? ReviewedDate { get; set; }

        public ReviewModel(Review review)
        {
            Id = review.Id;
            Text = review.Text;
            ReviewerName = review.ReviewerName;
            ReviewerSurName = review.ReviewerSurName;
            if (review.OverallRate != null)
                OverallRate = Math.Round(review.OverallRate.Value, 2);

            FoodRate = review.FoodRate;
            ServiceRate = review.ServiceRate;
            AmbienceRate = review.AmbienceRate;
            ReviewedDate = review.ReviewedDate?.Date;
        }
    }
}
