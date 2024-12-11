using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Repositories;
using Catalog.Entities.Review;



namespace Catalog.Services.Review
{
    public class ReviewService: IReviewService
    {
       
         private readonly IReviewsRepository _repo;

            public ReviewService(IReviewsRepository repo)
            {
                _repo = repo;
            }

            public async Task<List<Reviews>> GetAllReviewsAsync()
            {
                try
                {
                    List<Reviews> reviews = await _repo.GetAllReviewsAsync();
                    return reviews;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new List<Reviews>();
                }
            }

          

            public async Task<List<Reviews>> GetReviewsByProductAsync(int productId)
            {
                try
                {
                    List<Reviews> reviews = await _repo.GetReviewsByProductAsync(productId);
                    return reviews;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new List<Reviews>();
                }
            }

            public async Task<List<Reviews>> GetReviewsByUserAsync(int userId)
            {
                try
                {
                    List<Reviews> reviews = await _repo.GetReviewsByUserAsync(userId);
                    return reviews;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return new List<Reviews>();
                }
            }

            public async Task<bool> InsertReviewAsync(Reviews review)
            {
                try
                {
                    bool status = await _repo.InsertReviewsAsync(review);
                    return status;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }

            public async Task<bool> UpdateReviewAsync(Reviews review)
            {
                try
                {
                    bool status = await _repo.UpdateReviewsAsync(review);
                    return status;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }

            public async Task<bool> DeleteReviewAsync(int reviewId)
            {
                try
                {
                    bool status = await _repo.DeleteReviewsAsync(reviewId);
                    return status;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        }
    }


