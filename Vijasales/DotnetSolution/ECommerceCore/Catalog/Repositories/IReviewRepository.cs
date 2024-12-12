using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities.Review;

namespace Catalog.Repositories
{
    public interface IReviewsRepository
    {
        
            // Insert a new review
            Task<bool> InsertReviewsAsync(Reviews review);

            // Update an existing review
            Task<bool> UpdateReviewsAsync(Reviews review);

            // Delete a review by its ID
            Task<bool> DeleteReviewsAsync(int reviewId);

           

            // Get all reviews
            Task<List<Reviews>> GetAllReviewsAsync();

            // Get a review by its ID
            Task<Reviews> GetReviewsByIdAsync(int reviewId);

            // Get reviews by product ID
            Task<List<Reviews>> GetReviewsByProductAsync(int productId);

            // Get reviews by user ID
            Task<List<Reviews>> GetReviewsByUserAsync(int userId);

            // Get average rating for a product
            Task<double> GetAverageRatingByProductAsync(int productId);

            // Get the list of all review categories (if applicable)
           
        }
    }


