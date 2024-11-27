using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DBTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string conString = @"data source=DESKTOP-H1K53PL\SQLEXPRESS; database=Simplyfy; integrated security=SSPI";
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            try
            {
                con.Open();
                IDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                { 
                    string name=dr["Name"].ToString();
                    string description=dr["Description"].ToString();
                    int quantity = int.Parse(dr["Quantity"].ToString());
                    Console.WriteLine(name + "  "+ description + " "+ quantity);
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
    }
}
