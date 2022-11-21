using RBS.Application.Models;

namespace RBS.Application.Services.Reviews
{
    public interface IReviewService
    {
        Task<ReviewFullModel> GetRestaurantReviews(int restaurantId, CancellationToken cancellationToken);
    }
}
