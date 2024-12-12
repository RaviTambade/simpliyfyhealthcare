using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Catalog.Entities.Review;
using Microsoft.Extensions.Configuration;
using Catalog.Repositories;

namespace Catalog.Repositories.Review.Connected
{
    public class ReviewRepository : IReviewsRepository
    {
        private readonly string _conString;
        private readonly IConfiguration _configuration;

        public ReviewRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<Reviews>> GetAllReviewsAsync()
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsReviews";
                SqlCommand cmd = new SqlCommand(query, conn);
                List<Reviews> reviews = new List<Reviews>();

                try
                {
                    await conn.OpenAsync();
                    IDataReader dataReader = await cmd.ExecuteReaderAsync();

                    while (dataReader.Read())
                    {
                        Reviews review = new Reviews
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            ProductId = Convert.ToInt32(dataReader["ProductId"]),
                            UserId = Convert.ToInt32(dataReader["UserId"]),
                            Rating = Convert.ToInt32(dataReader["Rating"]),
                            ReviewText = dataReader["ReviewText"]?.ToString(),
                            Created_at= Convert.ToDateTime(dataReader["created_at"])
                        };

                        reviews.Add(review);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving reviews: {ex.Message}");
                }
                finally
                {
                    await conn.CloseAsync();
                }

                return reviews;
            }
        }

        // Async Insert method
        public async Task<bool> InsertReviewsAsync(Reviews review)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "INSERT INTO VsReviews (ProductId, UserId, Rating, ReviewText) " +
                               "VALUES (@ProductId, @UserId, @Rating, @ReviewText)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ProductId", review.ProductId));
                cmd.Parameters.Add(new SqlParameter("@UserId", review.UserId));
                cmd.Parameters.Add(new SqlParameter("@Rating", review.Rating));
                cmd.Parameters.Add(new SqlParameter("@ReviewText", review.ReviewText ?? (object)DBNull.Value));

                try
                {
                    await conn.OpenAsync();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Async Update method
        public async Task<bool> UpdateReviewsAsync(Reviews review)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "UPDATE VsReviews SET Rating = @Rating, ReviewText = @ReviewText WHERE Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", review.Id));
                cmd.Parameters.Add(new SqlParameter("@Rating", review.Rating));
                cmd.Parameters.Add(new SqlParameter("@ReviewText", review.ReviewText ?? (object)DBNull.Value));

                try
                {
                    await conn.OpenAsync();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Async Delete method
        public async Task<bool> DeleteReviewsAsync(int reviewId)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "DELETE FROM VsReviews WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", reviewId));

                try
                {
                    await conn.OpenAsync();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Async Get by Product method
        public async Task<List<Reviews>> GetReviewsByProductAsync(int productId)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsReviews WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
                List<Reviews> reviews = new List<Reviews>();

                try
                {
                    await conn.OpenAsync();
                    IDataReader dataReader = await cmd.ExecuteReaderAsync();

                    while (dataReader.Read())
                    {
                        Reviews review = new Reviews
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            ProductId = Convert.ToInt32(dataReader["ProductId"]),
                            UserId = Convert.ToInt32(dataReader["UserId"]),
                            Rating = Convert.ToInt32(dataReader["Rating"]),
                            ReviewText = dataReader["ReviewText"].ToString(),
                            Created_at = Convert.ToDateTime(dataReader["created_at"])
                        };

                        reviews.Add(review);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }

                return reviews;
            }
        }

        // Async Get by User method
        public async Task<List<Reviews>> GetReviewsByUserAsync(int userId)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsReviews WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@UserId", userId));
                List<Reviews> reviews = new List<Reviews>();

                try
                {
                    await conn.OpenAsync();
                    IDataReader dataReader = await cmd.ExecuteReaderAsync();

                    while (dataReader.Read())
                    {
                        Reviews review = new Reviews
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            ProductId = Convert.ToInt32(dataReader["ProductId"]),
                            UserId = Convert.ToInt32(dataReader["UserId"]),
                            Rating = Convert.ToInt32(dataReader["Rating"]),
                            ReviewText = dataReader["ReviewText"].ToString(),
                            Created_at = Convert.ToDateTime(dataReader["created_at"])
                        };

                        reviews.Add(review);
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }

                return reviews;
            }
        }

        // Async Get by Review ID method
        public async Task<Reviews> GetReviewsByIdAsync(int reviewId)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsReviews WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", reviewId));
                Reviews review = null;

                try
                {
                    await conn.OpenAsync();
                    IDataReader dataReader = await cmd.ExecuteReaderAsync();

                    if (dataReader.Read())
                    {
                        review = new Reviews
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            ProductId = Convert.ToInt32(dataReader["ProductId"]),
                            UserId = Convert.ToInt32(dataReader["UserId"]),
                            Rating = Convert.ToInt32(dataReader["Rating"]),
                            ReviewText = dataReader["ReviewText"].ToString(),
                            Created_at = Convert.ToDateTime(dataReader["created_at"])
                        };
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }

                return review;
            }
        }

        // Async Get average rating for a product
        public async Task<double> GetAverageRatingByProductAsync(int productId)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT AVG(Rating) FROM VsReviews WHERE ProductId = @ProductId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@ProductId", productId));
                double averageRating = 0;

                try
                {
                    await conn.OpenAsync();
                    var result = await cmd.ExecuteScalarAsync();
                    averageRating = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                }

                return averageRating;
            }
        }
    }
}
