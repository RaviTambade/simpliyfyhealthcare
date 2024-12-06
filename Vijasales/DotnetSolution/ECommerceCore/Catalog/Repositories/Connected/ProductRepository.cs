using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using Catalog.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Diagnostics;

namespace Catalog.Repositories.Connected
{
    public  class ProductRepository : IProductRepository
    {
        public string _conString;

        private IConfiguration _configuration;
        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _conString = this._configuration.GetConnectionString("DefaultConnection");
        }
        
        public bool Delete(int id)
        {
            /*IDbConnection conn = new SqlConnection(_conString);
            string query = "DELETE FROM VIVEK_PRODUCTS WHERE Id=" + id;
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            int rowsAffected;
            bool status = false;
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                status = true;

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return status;*/
            return true;
        }

        public List<Product> GetAll()
        {
            IDbConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsProducts";
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            IDataReader dataReader = null;
            List<Product> products = new List<Product>();
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = Convert.ToInt32(dataReader["Id"]);
                    int stock = Convert.ToInt32(dataReader["Stock"]);  // Quantity is mapped to Stock
                    decimal price = Convert.ToDecimal(dataReader["Price"]);  // Use decimal for price
                    string title = dataReader["Title"].ToString();
                    string desc = dataReader["Description"].ToString();
                    string brand = dataReader["Brand"].ToString();
                    string category = dataReader["Category"].ToString();
                    DateTime lastModified = Convert.ToDateTime(dataReader["LastModified"]);
                    string imageurl = dataReader["ImageUrl"].ToString();
                    Product product = new Product
                    {
                        Id = id,
                        Title = title,
                        Description = desc,
                        Brand = brand,
                        Price = price,      // Price as decimal
                        Stock = stock,      // Stock from Quantity
                        Category = category,
                        LastModified = lastModified,
                        ImageUrl = imageurl
                    };

                    // Add the product to the collection
                    products.Add(product);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return products;
        }

        public Product GetById(int id)
        {
            Product product = new Product();
            IDbConnection conn = new SqlConnection(_conString);
            string query = "SELECT * FROM VsProducts WHERE Id=" + id;
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            IDataReader dataReader = null;
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {

                    product.Id = Convert.ToInt32(dataReader["Id"]);
                    product.Title = dataReader["Title"].ToString();
                    product.Description = dataReader["Description"].ToString();
                    product.Brand = dataReader["Brand"].ToString();
                    product.Price = Convert.ToDecimal(dataReader["Price"]);
                    product.Stock = Convert.ToInt32(dataReader["Stock"]);
                    product.Category = dataReader["Category"].ToString();
                    product.LastModified = Convert.ToDateTime(dataReader["LastModified"]);
                    product.ImageUrl = dataReader["ImageUrl"].ToString();

                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return product;
        }

       

        public int GetCount()
        {
            /*
            IDbConnection conn = new SqlConnection(_conString);
            string query = "SELECT COUNT(*) FROM VIVEK_PRODUCTS ";
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            int count = 0;
            try
            {
                conn.Open();

                count = (int)cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }*/
            return 0;
        }
        public bool Insert(Product product)
        {
            /*IDbConnection conn = new SqlConnection(_conString);
            string query = "INSERT INTO VIVEK_PRODUCTS (Id,Title,Quantity,UnitPrice,Description,Imageurl) VALUES (" +
                product.Id + ",'" + product.Name + "'," + product.Quantity + "," + product.UnitPrice + ",'" + product.Description + "','" + product.ImageUrl
                + "')";
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            IDataReader dataReader;
            int rowsAffected = 0;
            bool status = false;
            try
            {
                conn.Open();

                rowsAffected = cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }*/
            return true;
        }

        public bool Update(Product product)
        {
            /*IDbConnection conn = new SqlConnection(_conString);
            string query = "UPDATE FROM VIVEK_PRODUCTS SET Title='" + product.Name + "',Quantity=" + product.Quantity +
                ",UnitPrice=" + product.UnitPrice + ",Description='" + product.Description + "',ImageUrl='" + product.ImageUrl + "'" +
                "WHERE Id=" + product.Id;
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            int rowsAffected = 0; bool status = false;
            try
            {
                conn.Open();
                rowsAffected = cmd.ExecuteNonQuery();
                status = true;


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }*/
            return true;
        }

    }
}
