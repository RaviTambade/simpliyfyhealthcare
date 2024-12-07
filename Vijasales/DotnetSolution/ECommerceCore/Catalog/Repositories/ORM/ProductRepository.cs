using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository
    {
        public List<Product> GetAll()
        {
            using (var ctx = new ProductContext())
            {
                var products = ctx.Products.ToList();
                return products;
            }
        }

        public Product GetById(int id)
        {
            using (var ctx = new ProductContext())
            {
                var product = ctx.Products.Find(id);
                return product;
            }
        }

        public bool Insert(Product product)
        {
            bool status = false;
            using (var ctx = new ProductContext())
            {
                ctx.Products.Add(product);
                ctx.SaveChanges();
                status = true;
            }
            return status;
        }

        public bool Delete(int Id)
        {
            bool status = false;
            using (var ctx = new ProductContext())
            {
                ctx.Products.Remove(ctx.Products.Find(Id));
                ctx.SaveChanges();
                status = true;
            }
            return status;
        }
    }
}
