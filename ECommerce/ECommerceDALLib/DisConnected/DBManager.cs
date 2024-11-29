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
namespace ECommerceDALLib.DisConnectedDataAccess
{
    public static  class DBManager:IDBManager
    {

      public   string conString = @"data source=DESKTOP-H1K53PL\SQLEXPRESS; database=Simplyfy; integrated security=SSPI";

        public   bool Insert(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
           /* string query = "INSERT INTO products (Id, Name, Description, UnitPrice, Quantity, Image)"
                           + "values(" + product.Id+ ", '" + product.Name + "', '" +)";

            */

            return status;
        }

        public   bool Update(Product product)
        {
            bool status = false;
            IDbConnection con = new SqlConnection(conString);
            /* string query = "INSERT INTO products (Id, Name, Description, UnitPrice, Quantity, Image)"
                            + "values(" + product.Id + ", '" + product.Name + "', '" +)";*/
            string query=string.Empty;



            return status;
        }

       

      

        public   List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products";
            IDbCommand cmd = new SqlCommand( query, con as SqlConnection);
            DataSet dataSet =new DataSet();
            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            adapter.Fill(dataSet);
            DataTable table= dataSet.Tables[0];
            foreach(DataRow row in table.Rows)
             {
                int id= int.Parse(row["Id"].ToString());
                string name=row["Name"].ToString(); 
                string description=row["Description"].ToString();
                double unitPrice = double.Parse(row["UnitPrice"].ToString());
                int quantity = int.Parse(row["quantity"].ToString());
                string image = row["Image"].ToString();
                Product product = new Product();
                product.Name = name;
                product.Description = description;
                product.Quantity = quantity;
                product.Image = image;
                products.Add(product);
            }
            return products;
        }

         public   Product GetById(int id)
        {
            List<Product> products = new List<Product>();
            products = GetAll();
            Product theProduct = products.Find((product) => (product.Id == id));
            return theProduct;
        }

       public  bool IDBManager.Delete(int id)
        {
            List<Product> products = new List<Product>();
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT * from products";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);
            DataSet dataSet = new DataSet();

            IDataAdapter adapter = new SqlDataAdapter(cmd as SqlCommand);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter as SqlDataAdapter);
            adapter.Fill(dataSet);
            DataTable table = dataSet.Tables[0];
            DataRowCollection rows = table.Rows;
            DataRow foundRow = null;
            foreach (DataRow row in rows)
            {
                int rowId = int.Parse(row["Id"].ToString());
                if (rowId == id)
                {
                    foundRow.Delete();
                }
            }

            if (foundRow != null)
            {
                rows.Remove(foundRow);
            }
            adapter.Update(dataSet);

        }

      public   int IDBManager.GetCount()
        {
            IDbConnection con = new SqlConnection(conString);
            string query = "SELECT COUNT(*) from products";
            IDbCommand cmd = new SqlCommand(query, con as SqlConnection);

        }
    }
}
