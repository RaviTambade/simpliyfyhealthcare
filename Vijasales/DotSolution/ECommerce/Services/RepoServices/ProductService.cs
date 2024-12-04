using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
using Specification;
using BinaryDataRepositoryLIb;
using JsonDataRepositoryLib;
using System.Security;
using System.Net.Http;
namespace ECommerceServices
{
    //Service class is special class 
    // we write for implementing core logic  which could be 
    // used inside web based project , or console application
    // or in another library.

    public class ProductService : IProductService
    {
        //Sampling data for testing purpose
        public bool Seeding()
        {
            bool status = false;
            List<Product> products = new List<Product>();
            products.Add(new Product { Id = 1, Name = "gerbera", Description = "Wedding Flower", UnitPrice = 12, Quantity = 2000, Image = "/Images/gerbera.jpg" });
            products.Add(new Product { Id = 2, Name = "rose", Description = "Valentine Flower", UnitPrice = 23, Quantity = 9000, Image = "/images/rose.jpg" });
            products.Add(new Product { Id = 3, Name = "lily", Description = "Delicate Flower", UnitPrice = 2, Quantity = 7000, Image = "/images/lily.jpg" });
            products.Add(new Product { Id = 4, Name = "jasmine", Description = "Fregrance Flower", UnitPrice = 12, Quantity = 55000, Image = "/images/jasmines.jpg" });
            products.Add(new Product { Id = 5, Name = "lotus", Description = "Worship Flower", UnitPrice = 45, Quantity = 15000, Image = "/images/lotus.jpg" });

            // IDataRepository<Product> repo = new BinaryRepository<Product>();
            IDataRepository<Product> repo = new JsonRepository<Product>();
            status = repo.Serialize(@"D:/products.json", products);
            return status;
        }
        public bool Delete(int id)
        {
            Product theProduct = Get(id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                IDataRepository<Product> repo = new JsonRepository<Product>();
                 repo.Serialize(@"D:/products.json", allProducts);
            }
            return false;
        }

        public Product Get(int id)
        {
            Product foundProduct = null;
            List<Product> products = GetAll();
            foreach(Product p in products)
            {
                if(p.Id == id)
                {
                    foundProduct = p;

                }
            }
            return foundProduct;
                }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            IDataRepository<Product> repository = new JsonRepository<Product>();
            products = repository.Deserialize(@"D:/products.json");
            return products;
        }

        public bool Insert(Product product)
        {
            List<Product> allProducts = GetAll();
            allProducts.Add(product);
            IDataRepository<Product> repo = new JsonRepository<Product>();
            repo.Serialize(@"D:/products.json", allProducts);

            return false;    
        }

        public bool Update(Product productTobeUpdated)
        {
            Product theProduct = Get(productTobeUpdated.Id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                allProducts.Remove(theProduct);
                allProducts.Add(productTobeUpdated);
                IDataRepository<Product> repo = new JsonRepository<Product>();
                repo.Serialize(@"D:/products.json", allProducts);
            }
            return false;
        }
    }
}
