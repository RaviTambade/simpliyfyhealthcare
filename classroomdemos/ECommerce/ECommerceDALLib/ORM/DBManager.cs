using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ECommerceEntities;
using System.Runtime.Remoting.Contexts;
using System.Data.Entity;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
namespace ECommerceDALLib
{
    public class ECommerceContext : DbContext
    {
        public   string conString = @"data source=DESKTOP-H1K53PL\SQLEXPRESS; database=Simplyfy; integrated security=SSPI";
        public DbSet<Product> Products { get; set; }
        public ECommerceContext() : base("name=conString") { }
    }

    public static  class DBManager
    {
        public static bool Insert(Product product)
        {
            bool status = false;
           
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;
           
            return status;
        }

        public static void Delete( int id)
        {
         
        }

        public static void GetCount()
        {   
        }


        public static List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var context = new ECommerceContext())
            {
                var dbProducts = context.Products.ToList();
                foreach (var product in dbProducts)
                {
                    Product theProduct = new Product();
                    theProduct.Name = product.Name;
                    theProduct.Description = product.Description;
                    theProduct.Quantity = product.Quantity;
                    theProduct.Image = product.Image;
                    products.Add(product);
                }
            }
            return products;
        }

         public static Product GetById(int id)
        {

            return new Product();

        }

    }
}
