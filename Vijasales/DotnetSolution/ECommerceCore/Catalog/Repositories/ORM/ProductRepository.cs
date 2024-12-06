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
    }
}
