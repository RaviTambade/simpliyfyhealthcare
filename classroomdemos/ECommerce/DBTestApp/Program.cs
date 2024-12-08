using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;


/*
 
CREATE TABLE [dbo].[products](
	[Id] [nchar](10) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](max) NULL,
	[UnitPrice] [money] NOT NULL,
	[Quantity] [int] NULL,
	[Image] [varchar](max) NULL,
 CONSTRAINT [PK_products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

  
 */

namespace DBTestApp
{
    internal class Program
    {
        public static string conString = @"data source=DESKTOP-H1K53PL\SQLEXPRESS; database=Simplyfy; integrated security=SSPI";

        public bool InsertRecord(int id, string name, string decription, int quantity, double unitPrice)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            string query = "INSERT INTO products (Id, Name, Description, UnitPrice, Quantity, Image)"
                           + "values("+id + ", '"+ name+ "', '"+)";

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
        public static void DeleteReord()
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

        public static void ShowRecordCount()
        { 

            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT COUNT(*) from products";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
               int count= int.Parse(cmd.ExecuteScalar().ToString());
               Console.WriteLine("Records {0}", count,56);
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
    

        public static void ShowAllRecords() {

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
                    Console.WriteLine(name + "  " + description + " " + quantity);
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
        }


        public static void DemoStoredProcedure()
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "RegisterUser";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
           // cmd.CommandText = query;
          
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

        static void Main(string[] args)
        {

            ShowAllRecords();

        }
    }
}
