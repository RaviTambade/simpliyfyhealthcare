using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


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
