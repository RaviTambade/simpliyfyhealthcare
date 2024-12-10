using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Catalog.Entities;
using System.Configuration;

namespace Catalog.Repositories.Connected
{
    public class ProductRepository : IProductRepository
    {
        public static string _conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;

        // Async Delete method
        public async Task<bool> DeleteAsync(int id)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "DELETE FROM VsProducts WHERE Id = @Id";
                try
                {
                    await conn.OpenAsync();  // Open the connection asynchronously

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();  // Async execute
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }

        // Async GetAll method
        public async Task<List<Product>> GetAllAsync()
        {
            IDbConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsProducts";
            List<Product> products = new List<Product>();

            try
            {
                // Simulating async behavior for opening the connection using Task.Run
                await Task.Run(() => conn.Open());  // Simulate async Open

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;

                // Use Task.Run for ExecuteReader, simulating async behavior
                using (IDataReader dataReader = await Task.Run(() => cmd.ExecuteReader()))  // Simulate async ExecuteReader
                {
                    while (await Task.Run(() => dataReader.Read()))  // Simulate async Read
                    {
                        Product product = new Product
                        {
                            Id = Convert.ToInt32(dataReader["Id"]),
                            Title = dataReader["Title"].ToString(),
                            Description = dataReader["Description"].ToString(),
                            Brand = dataReader["Brand"].ToString(),
                            Price = Convert.ToDecimal(dataReader["Price"]),
                            Stock = Convert.ToInt32(dataReader["Stock"]),
                            Category = dataReader["Category"].ToString(),
                            LastModified = Convert.ToDateTime(dataReader["LastModified"]),
                            ImageUrl = dataReader["ImageUrl"].ToString()
                        };
                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                // Output the error message if something goes wrong
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }
            finally
            {
                // Always ensure the connection is closed
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return products;
        }


        // Async GetById method
        public async Task<Product> GetByIdAsync(int id)
        {
            using (IDbConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsProducts WHERE Id = @Id";
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                Product product = null;

                try
                {
                    conn.Open();  // Using synchronous Open method
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            product = new Product
                            {
                                Id = Convert.ToInt32(dataReader["Id"]),
                                Title = dataReader["Title"].ToString(),
                                Description = dataReader["Description"].ToString(),
                                Brand = dataReader["Brand"].ToString(),
                                Price = Convert.ToDecimal(dataReader["Price"]),
                                Stock = Convert.ToInt32(dataReader["Stock"]),
                                Category = dataReader["Category"].ToString(),
                                LastModified = Convert.ToDateTime(dataReader["LastModified"]),
                                ImageUrl = dataReader["ImageUrl"].ToString()
                            };
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception: {ex.Message}");
                }

                return product;
            }
        }

        // Async GetCount method
        public async Task<int> GetCountAsync()
        {
            using (IDbConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT COUNT(*) FROM VsProducts";
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                int count = 0;

                try
                {
                    conn.Open();  // Using synchronous Open method
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception: {ex.Message}");
                }

                return count;
            }
        }

        // Async Insert method
        public async Task<bool> InsertAsync(Product product)
        {
            using (IDbConnection conn = new SqlConnection(_conString))
            {
                string query = "INSERT INTO VsProducts (Title, Stock, Price, Description, Category, ImageUrl, Brand) " +
                               "VALUES (@Title, @Stock, @Price, @Description, @Category, @ImageUrl, @Brand)";

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@Title", product.Title));
                cmd.Parameters.Add(new SqlParameter("@Stock", product.Stock));
                cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                cmd.Parameters.Add(new SqlParameter("@Category", product.Category));
                cmd.Parameters.Add(new SqlParameter("@ImageUrl", product.ImageUrl));
                cmd.Parameters.Add(new SqlParameter("@Brand", product.Brand));

                try
                {
                    conn.Open();  // Using synchronous Open method
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Exception: {ex.Message}");
                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Exception: {ex.Message}");
                    return false;
                }
            }
        }

        // Async Update method
        public async Task<bool> UpdateAsync(Product product)
        {
            using (IDbConnection conn = new SqlConnection(_conString))
            {
                string query = "UPDATE VsProducts SET Title = @Title, Stock = @Stock, Price = @Price, " +
                               "Description = @Description, Category = @Category, ImageUrl = @ImageUrl, Brand = @Brand WHERE Id = @Id";

                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@Id", product.Id));
                cmd.Parameters.Add(new SqlParameter("@Title", product.Title));
                cmd.Parameters.Add(new SqlParameter("@Stock", product.Stock));
                cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                cmd.Parameters.Add(new SqlParameter("@Category", product.Category));
                cmd.Parameters.Add(new SqlParameter("@ImageUrl", product.ImageUrl));
                cmd.Parameters.Add(new SqlParameter("@Brand", product.Brand));

                try
                {
                    conn.Open();  // Using synchronous Open method
                    int rowsAffected = cmd.ExecuteNonQuery();
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

        // Async GetByCategory method
        public async Task<List<Product>> GetByCategoryAsync(string category)
        {
            using (IDbConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsProducts WHERE Category = @Category";
                IDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.Parameters.Add(new SqlParameter("@Category", category));
                List<Product> products = new List<Product>();

                try
                {
                    conn.Open();  // Using synchronous Open method
                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Product product = new Product
                            {
                                Id = Convert.ToInt32(dataReader["Id"]),
                                Title = dataReader["Title"].ToString(),
                                Description = dataReader["Description"].ToString(),
                                Brand = dataReader["Brand"].ToString(),
                                Price = Convert.ToDecimal(dataReader["Price"]),
                                Stock = Convert.ToInt32(dataReader["Stock"]),
                                Category = dataReader["Category"].ToString(),
                                LastModified = Convert.ToDateTime(dataReader["LastModified"]),
                                ImageUrl = dataReader["ImageUrl"].ToString()
                            };
                            products.Add(product);
                        }
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

                return products;
            }
        }
    }
}
