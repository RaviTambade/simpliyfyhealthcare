using Catalog.Entities.Review;
using Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
      
            private readonly IReviewService _reviewService;

            public ReviewsController(IReviewService reviewService)
            {
                _reviewService = reviewService;
            }

            // GET: api/reviews
            [HttpGet]
            public async Task<ActionResult<List<Reviews>>> GetAllReviews()
            {
                var reviews = await _reviewService.GetAllReviewsAsync();
                if (reviews == null || reviews.Count == 0)
                {
                    return NotFound("No reviews found.");
                }
                return Ok(reviews);
            }

            // GET: api/reviews/{productId}
            [HttpGet("{productId}")]
            public async Task<ActionResult<List<Reviews>>> GetReviewsByProduct(int productId)
            {
                var reviews = await _reviewService.GetReviewsByProductAsync(productId);
                if (reviews == null || reviews.Count == 0)
                {
                    return NotFound($"No reviews found for product with ID {productId}.");
                }
                return Ok(reviews);
            }

            // GET: api/reviews/user/{userId}
            [HttpGet("user/{userId}")]
            public async Task<ActionResult<List<Reviews>>> GetReviewsByUser(int userId)
            {
                var reviews = await _reviewService.GetReviewsByUserAsync(userId);
                if (reviews == null || reviews.Count == 0)
                {
                    return NotFound($"No reviews found for user with ID {userId}.");
                }
                return Ok(reviews);
            }

            // POST: api/reviews
            [HttpPost]
            public async Task<ActionResult> AddReview([FromBody] Reviews review)
            {
                if (review == null)
                {
                    return BadRequest("Review data is required.");
                }

                bool result = await _reviewService.InsertReviewAsync(review);

                if (result)
                {
                    return CreatedAtAction(nameof(GetReviewsByProduct), new { productId = review.ProductId }, review);
                }

                return BadRequest("Failed to insert the review.");
            }

            // PUT: api/reviews/{reviewId}
            [HttpPut("{reviewId}")]
            public async Task<ActionResult> UpdateReview(int reviewId, [FromBody] Reviews review)
            {
                if (review == null )
                {
                    return BadRequest("Review data is invalid.");
                }

                bool result = await _reviewService.UpdateReviewAsync(review);

                if (result)
                {
                    return Ok(review);
                }

                return NotFound($"Review with ID {reviewId} not found.");
            }

            // DELETE: api/reviews/{reviewId}
            [HttpDelete("{reviewId}")]
            public async Task<ActionResult> DeleteReview(int reviewId)
            {
                bool result = await _reviewService.DeleteReviewAsync(reviewId);

                if (result)
                {
                    return NoContent(); // 204 No Content indicates successful deletion
                }

                return NotFound($"Review with ID {reviewId} not found.");
            }
        }
    }

