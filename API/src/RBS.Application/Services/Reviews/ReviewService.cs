using RBS.Application.Models;
using RBS.Data.Repositories;
using RBS.Domain.Reviews;

namespace RBS.Application.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<Review> _repository;

        public ReviewService(IRepository<Review> repository)
        {
            _repository = repository;
        }

        public async Task<ReviewFullModel> GetRestaurantReviews(int restaurantId)
        {
            var reviews = await _repository.GetListAsync(predicate: x => x.RestaurantId == restaurantId);

            return new ReviewFullModel(reviews);
        }
    }
}
