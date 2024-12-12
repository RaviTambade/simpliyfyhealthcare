using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Entities.Review;

namespace Catalog.Services
{
    public interface IReviewService
    {
        Task<List<Reviews>> GetAllReviewsAsync();
       
        Task<List<Reviews>> GetReviewsByProductAsync(int productId);
        Task<List<Reviews>> GetReviewsByUserAsync(int userId);
        Task<bool> InsertReviewAsync(Reviews review);
        Task<bool> UpdateReviewAsync(Reviews review);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
