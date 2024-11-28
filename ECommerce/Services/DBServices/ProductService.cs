using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
using Specification;
using System.Security;
using System.Net.Http;
namespace ECommerceServices.DB
{
 
    public class ProductService : IProductService
    {
       public bool Delete(int id)
        {
            Product theProduct = Get(id);
             
            return false;
        }

        public Product Get(int id)
        {
            Product foundProduct = null;
            
            return foundProduct;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
              return products;
        }

        public bool Insert(Product product)
        {
            List<Product> allProducts = GetAll();
            
            return false;
        }

        public bool Update(Product productTobeUpdated)
        {
            Product theProduct = Get(productTobeUpdated.Id);
            
            return false;
        }
    }
}
