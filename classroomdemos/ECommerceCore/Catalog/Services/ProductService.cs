using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Repositories;
namespace Catalog.Services
{
    public class ProductService : IProductService
    {
        //Sampling data for testing purpose
        private IDataRepository _repo;
        public ProductService(IDataRepository repo) {
            _repo = repo;
        }

        public bool Delete(int id)
        {
            Product theProduct = Get(id);
            if (theProduct != null)
            {
                List<Product> allProducts = GetAll();
                
            }
            return false;
        }

        public Product Get(int id)
        {
            Product foundProduct = null;
            List<Product> products = GetAll();
            foreach (Product p in products)
            {
                if (p.Id == id)
                {
                    foundProduct = p;

                }
            }
            return foundProduct;
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            products=_repo.GetAll();
            return products;
        }

        public bool Insert(Product product)
        {
            List<Product> allProducts = GetAll();
            allProducts.Add(product);
           

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
                
            }
            return false;
        }
    }
}
