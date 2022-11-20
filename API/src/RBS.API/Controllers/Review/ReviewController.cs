using Microsoft.AspNetCore.Mvc;
using RBS.Application.Models;
using RBS.Application.Services.Reviews;

namespace RBS.API.Controllers.Review
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ReviewController : ApiControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("GetRestaurantReviews/{restaurantId}")]
        [ProducesResponseType(typeof(ReviewFullModel), StatusCodes.Status200OK)]
        public async Task<ActionResult<ReviewFullModel>> GetRestaurantReviews([FromRoute] int restaurantId, CancellationToken cancellationToken)
        {
            var result = await _reviewService.GetRestaurantReviews(restaurantId, cancellationToken);
            return Ok(result);
        }
    }
}
