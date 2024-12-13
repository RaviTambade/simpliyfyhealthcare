using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Catalog.Entities;
using Microsoft.Extensions.Configuration;

namespace Catalog.Repositories.Connected
{
    public class ProductRepository : IProductRepository
    {
        public string _conString;
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection");
        }

        // Async Delete method
        public async Task<bool> DeleteAsync(int id)
        {
            
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "DELETE FROM VsProducts WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));

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
                finally
                {
                   
                    await conn.CloseAsync();
                }
            }
        }



        // Async GetAll method
        public async Task<List<Product>> GetAllAsync()
        {
          
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT * FROM VsProducts";
                SqlCommand cmd = new SqlCommand(query, conn);
                List<Product> products = new List<Product>();

                try
                {
                    
                    await conn.OpenAsync();
                    IDataReader dataReader = await cmd.ExecuteReaderAsync();


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
                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                   
                    await conn.CloseAsync();
                }

                return products;
            }
        }

      
        public async Task<Product> GetByIdAsync(int id)
{
    using (SqlConnection conn = new SqlConnection(_conString))
    {
        string query = "SELECT * FROM VsProducts WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(query, conn);
        cmd.Parameters.Add(new SqlParameter("@Id", id));
        Product product = null;

        try
        {
            // Open connection asynchronously
            await conn.OpenAsync();

            // Execute the query asynchronously and process the results
            using (IDataReader dataReader = await cmd.ExecuteReaderAsync())
            {
                if ( dataReader.Read())  // Read asynchronously
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
        finally
        {
            // Close the connection asynchronously (although `using` takes care of it, but it's good practice to ensure)
            await conn.CloseAsync();
        }

        return product;  // Return the found product or null if not found
    }
}

        public async Task<int> GetCountAsync()
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "SELECT COUNT(*) FROM VsProducts";
                SqlCommand cmd = new SqlCommand(query, conn);
                int count = 0;

                try
                {
                   
                    await conn.OpenAsync();
                   
                    count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
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


     
        public async Task<bool> InsertAsync(Product product)
        {
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                string query = "INSERT INTO VsProducts (Title, Stock, Price, Description, Category, ImageUrl,Brand) " +
                               "VALUES (@Title, @Stock, @Price, @Description, @Category, @ImageUrl,@Brand)";

           
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Title", product.Title));
                cmd.Parameters.Add(new SqlParameter("@Stock", product.Stock));
                cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                cmd.Parameters.Add(new SqlParameter("@Category", product.Category));
                cmd.Parameters.Add(new SqlParameter("@ImageUrl", product.ImageUrl));
                cmd.Parameters.Add(new SqlParameter("@Brand", product.Brand));


                try
                {
                 
                    await conn.OpenAsync();

                  
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                
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
            using (SqlConnection conn = new SqlConnection(_conString))
            {
                
                string query = "UPDATE VsProducts SET Title = @Title, Stock = @Stock, Price = @Price, " +
                               "Description = @Description, Category = @Category, ImageUrl = @ImageUrl ,Brand=@brand WHERE Id = "+product.Id;

              
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", product.Id));
                cmd.Parameters.Add(new SqlParameter("@Title", product.Title));
                cmd.Parameters.Add(new SqlParameter("@Stock", product.Stock));
                cmd.Parameters.Add(new SqlParameter("@Price", product.Price));
                cmd.Parameters.Add(new SqlParameter("@Description", product.Description));
                cmd.Parameters.Add(new SqlParameter("@Category", product.Category));
                cmd.Parameters.Add(new SqlParameter("@ImageUrl", product.ImageUrl));
                cmd.Parameters.Add(new SqlParameter("@brand", product.Brand));

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


        // Async GetByCategory method
        public async Task<List<Product>> GetByCategoryAsync(string category)
        {
            try
            {
                using (var conn = new SqlConnection(_conString))
                {
                    string query = "SELECT * FROM VsProducts WHERE Category = @Category";
                    var cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add(new SqlParameter("@Category", category));

                    var products = new List<Product>();

                    try
                    {

                        if (string.IsNullOrEmpty(category))
                        {
                            Console.WriteLine("Category is empty or null");
                            return products;
                        }

                        Console.WriteLine($"Query: {query}, Category: {category}");

                        await conn.OpenAsync();

                        using (var dataReader = await cmd.ExecuteReaderAsync())
                        {

                            Console.WriteLine($"Columns returned: {dataReader.FieldCount}");



                            while (await dataReader.ReadAsync())
                            {
                                var product = new Product
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
                    
                    return products;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return new List<Product>();
            }

        }


        // Async GetByBrand method
        public async Task<List<Product>> GetByBrandAsync(string brand)
        {
            try
            {
                using (var conn = new SqlConnection(_conString))
                {
                    string query = "SELECT * FROM VsProducts WHERE Brand = @Brand";
                    var cmd = new SqlCommand(query, conn);

                    cmd.Parameters.Add(new SqlParameter("@Brand", brand));

                    var products = new List<Product>();

                    try
                    {

                        if (string.IsNullOrEmpty(brand))
                        {
                            Console.WriteLine("brand is empty or null");
                            return products;
                        }

                        Console.WriteLine($"Query: {query}, Brand: {brand}");

                        await conn.OpenAsync();

                        using (var dataReader = await cmd.ExecuteReaderAsync())
                        {

                            Console.WriteLine($"Columns returned: {dataReader.FieldCount}");



                            while (await dataReader.ReadAsync())
                            {
                                var product = new Product
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

                    return products;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return new List<Product>();
            }
            

        }

        public async Task<List<Product>> GetByCategoryBrandAsync(string category, string brand)
        {
            try
            {
                using (var conn = new SqlConnection(_conString))
                {
                    
                    string query = "SELECT * FROM VsProducts WHERE Category = @Category AND Brand = @Brand";

                    var cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.Add(new SqlParameter("@Category", category));
                    cmd.Parameters.Add(new SqlParameter("@Brand", brand));

                    var products = new List<Product>();

                    try
                    {
                        if (string.IsNullOrEmpty(category) || string.IsNullOrEmpty(brand))
                        {
                            Console.WriteLine("Category or Brand is empty or null");
                            return products;
                        }

                        Console.WriteLine($"Query: {query}, Category: {category}, Brand: {brand}");

                        await conn.OpenAsync();

                        using (var dataReader = await cmd.ExecuteReaderAsync())
                        {
                            Console.WriteLine($"Columns returned: {dataReader.FieldCount}");

                            while (await dataReader.ReadAsync())
                            {
                                var product = new Product
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

                    return products;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return new List<Product>();
            }
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            try
            {
                using (var conn = new SqlConnection(_conString))
                {
                    string query = "SELECT DISTINCT Category FROM VsProducts";
                    var cmd = new SqlCommand(query, conn);

                    var categories = new List<string>();

                    try
                    {
                        Console.WriteLine($"Query: {query}");

                        await conn.OpenAsync();

                        using (var dataReader = await cmd.ExecuteReaderAsync())
                        {
                            Console.WriteLine($"Columns returned: {dataReader.FieldCount}");

                            while (await dataReader.ReadAsync())
                            {
                                var category = dataReader["Category"].ToString();
                                if (!string.IsNullOrEmpty(category))
                                {
                                    categories.Add(category);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error: {ex.Message}");
                    }

                    return categories;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task<List<string>> GetBrandsAsync(string category)
        {
            throw new NotImplementedException();
        }
    }
}
