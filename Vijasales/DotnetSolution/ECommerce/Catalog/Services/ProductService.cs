using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Repositories;
using Catalog.Repositories.Connected;

namespace Catalog.Services
{
    public class ProductService : IProductService
    {
      
        public async Task<bool> DeleteAsync(int id)
        {
           IProductRepository _repo=new ProductRepository();
           bool status= await _repo.DeleteAsync(id);
            return status;
        }

        public async Task<List<Product>> GetAllAsync()
        {
           IProductRepository _repo=new ProductRepository();
            List<Product> products = await _repo.GetAllAsync();
            return products;
        }


        public async Task<Product> GetAsync(int id)
        {
            IProductRepository _repo = new ProductRepository();

            Product product = await _repo.GetByIdAsync(id);
            return product;
        }


        public  async Task<List<Product>> GetByCategoryAsync(string category)
        {
            IProductRepository _repo = new ProductRepository();

            List<Product> products = await _repo.GetByCategoryAsync(category);
            return products;
        }

        public async Task<bool> InsertAsync(Product product)
        {
            IProductRepository _repo = new ProductRepository();

            bool status = await _repo.InsertAsync(product);
            return status;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            IProductRepository _repo = new ProductRepository();

            bool status = await _repo.UpdateAsync(product);
            return status;
        }
    }
}
