using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ECommerceEntities;
namespace ECommerceDALLib
{
    public static  class DBManager
    {

        public static string conString = @"data source=DESKTOP-H1K53PL\SQLEXPRESS; database=Simplyfy; integrated security=SSPI";

        public static bool Insert(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            string query = "INSERT INTO products (Id, Name, Description, UnitPrice, Quantity, Image)"
                           + "values(" + product.Id+ ", '" + product.Name + "', '" +)";

            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            string query = "INSERT INTO products (Id, Name, Description, UnitPrice, Quantity, Image)"
                           + "values(" + product.Id + ", '" + product.Name + "', '" +)";

            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                status = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return status;
        }

        public static void Delete( int id)
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "DELETE from products WHERE Id=2";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public static void GetCount()
        {

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT COUNT(*) from products";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                int count = int.Parse(cmd.ExecuteScalar().ToString());
                Console.WriteLine("Records {0}", count, 56);
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
        }


        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());

                    Product product = new Product();
                    product.Name = name;
                    product.Description = description;
                    product.Quantity = quantity;
                    products.Add(product);

                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
            return products;

        }

         public static Product GetById(int id)
        {
            List<Product> products = new List<Product>();

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products WHERE Id="+id;
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr["Name"].ToString();
                    string description = dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());

                    Product product = new Product();
                    product.Name = name;
                    product.Description = description;
                    product.Quantity = quantity;
                    products.Add(product);

                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

                con.Close();
            }
            return products;
        }

    }
}
