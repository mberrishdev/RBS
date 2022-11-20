using Common.Repository.Repository;
using RBS.Application.Models;
using RBS.Domain.Reviews;

namespace RBS.Application.Services.Reviews
{
    public class ReviewService : IReviewService
    {
        private readonly IQueryRepository<Review> _queryRepository;

        public ReviewService(IQueryRepository<Review> queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<ReviewFullModel> GetRestaurantReviews(int restaurantId, CancellationToken cancellationToken)
        {
            var reviews = await _queryRepository.GetListAsync(predicate: x => x.RestaurantId == restaurantId, cancellationToken: cancellationToken);
            return new ReviewFullModel(reviews);
        }
    }
}
