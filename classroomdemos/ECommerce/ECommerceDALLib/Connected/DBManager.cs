using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ECommerceEntities;
using Specification;


namespace ECommerceDALLib.ConnectedDataAccess
{
    public static  class DBManager:IDBManager
    {

        public static string connString = @"data source=DESKTOP-H1K53PL\SQLEXPRESS; database=Simplyfy; integrated security=SSPI";
        public bool Delete(int id)
        {
            IDbConnection conn = new SqlConnection(connString);
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
            return status;
        }

        public List<Product> GetAll()
        {
            IDbConnection conn = new SqlConnection(connString);
            string query = "SELECT * FROM VIVEK_PRODUCTS";
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            IDataReader dataReader = null;
            List<Product> products = new List<Product>();
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    int id = int.Parse(dataReader["Id"].ToString());
                    int quantity = int.Parse(dataReader["Quantity"].ToString());
                    int unitPrice = (int)double.Parse(dataReader["UnitPrice"].ToString());
                    string title = dataReader["Title"].ToString();
                    string desc = dataReader["Description"].ToString();
                    string imageurl = dataReader["ImageUrl"].ToString();
                    Product product = new Product { Id = id, Quantity = quantity, UnitPrice = unitPrice, Title = title, Description = desc, ImageUrl = imageurl };
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
            IDbConnection conn = new SqlConnection(connString);
            string query = "SELECT * FROM VIVEK_PRODUCTS WHERE Id=" + id;
            IDbCommand cmd = new SqlCommand(query, conn as SqlConnection);
            IDataReader dataReader = null;
            Product product = null;
            try
            {
                conn.Open();
                dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    int Id = int.Parse(dataReader["Id"].ToString());
                    int quantity = int.Parse(dataReader["Quantity"].ToString());
                    int unitPrice = (int)double.Parse(dataReader["UnitPrice"].ToString());
                    string title = dataReader["Title"].ToString();
                    string desc = dataReader["Description"].ToString();
                    string imageurl = dataReader["ImageUrl"].ToString();
                    product = new Product { Id = Id, Quantity = quantity, UnitPrice = unitPrice, ImageUrl = imageurl, Title = title, Description = desc };
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
            IDbConnection conn = new SqlConnection(connString);
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
            }
            return count;
        }
        public bool Insert(Product product)
        {
            IDbConnection conn = new SqlConnection(connString);
            string query = "INSERT INTO VIVEK_PRODUCTS (Id,Title,Quantity,UnitPrice,Description,Imageurl) VALUES (" +
                product.Id + ",'" + product.Title + "'," + product.Quantity + "," + product.UnitPrice + ",'" + product.Description + "','" + product.ImageUrl
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
            }
            return status;
        }

        public bool Update(Product product)
        {
            IDbConnection conn = new SqlConnection(connString);
            string query = "UPDATE FROM VIVEK_PRODUCTS SET Title='" + product.Title + "',Quantity=" + product.Quantity +
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
            }
            return status;
        }


    }
}
