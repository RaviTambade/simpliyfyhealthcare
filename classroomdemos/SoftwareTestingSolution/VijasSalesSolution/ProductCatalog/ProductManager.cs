using ProductCatalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Repositories
{
    public class ProductManager
    {
        public static List<Product> GetAll()
        {
            var products = new List<Product>();
            products.Add(new Product { Name = "Jasmine", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            products.Add(new Product { Name = "Rose", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            products.Add(new Product { Name = "Tulip", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            products.Add(new Product { Name = "Lotus", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });
            products.Add(new Product { Name = "Marigold", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 });

            return products;
        }

        public static Product GetById(int id)
        {
            //database code will take input as id 
            //that will search product with id 
            //product will be returned
            Product product = new Product { Name = "Jasmine", Description = "Smelling Flower", Category = "flowers", StockAvailable = 4500, UnitPrice = 12 };
            return product;
        }

        public static bool Insert(Product product)
        {
            List<Product> products = GetAll();
            products.Add(product);
            return true;

        }

        public static bool Update(Product product)
        {
            List<Product> products = GetAll();
            //products.Add(product);
            //logic to update exsting product from collection
            return true;

        }
        public static bool Delete(Product product)
        {
            List<Product> products = GetAll();
            //logic to remove product from collection
            return true;
        }
    }
}