
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace ORMTestApp
{
    [Table("products")]
    public class Product
    {
        [Key]
        public string Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Description;
        }
    }

    public class ECommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ECommerceContext() : base("name=conString") { }
    }

    public static class DBManager
    {
        public static void Delete(int id)
        {
            string str_Id = id.ToString();
            using (var context = new ECommerceContext())
            {
                var product = context.Products.SingleOrDefault(s => s.Id == str_Id);
                if (product != null)
                {
                    context.Products.Remove(product);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }


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
            Product product = null;
            string str_Id = id.ToString();
            using (var context = new ECommerceContext())
            {
                product = context.Products.SingleOrDefault(s => s.Id == str_Id);

            }
            return product;
        }
        public static bool Insert(Product product)
        {
            bool status = false;
            using (var context = new ECommerceContext())
            {
                context.Products.Add(product);
            }
            return status;
        }

        public static bool Update(Product product)
        {
            bool status = false;

            using (var context = new ECommerceContext())
            {
                var foundProduct = context.Products.SingleOrDefault(s => s.Id == product.Id);
                if (foundProduct != null)
                {
                    foundProduct.Name = product.Name;
                    foundProduct.Description = product.Description;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }


            return status;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products=DBManager.GetAll();
            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
