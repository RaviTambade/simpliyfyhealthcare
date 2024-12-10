using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Repositories;


namespace Catalog.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> DeleteAsync(int id)
        {
           bool status= await _repo.DeleteAsync(id);
            return status;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            
            List<Product> products = await _repo.GetAllAsync();
            return products;
        }


        public async Task<Product> GetAsync(int id)
        {
            Product product = await _repo.GetByIdAsync(id);
            return product;
        }

        public async Task<List<string>> GetBrandsAsync(string category)
        {
            try
            {
                List<string> brands = await _repo.GetBrandsAsync(category);
                return brands;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<string>();
            }
        }

        public async Task<List<Product>> GetByBrandAsync(string brand)
        {
            try
            {
                List<Product> products = await _repo.GetByBrandAsync(brand);
                return products;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Product>();
            }
        }

        public  async Task<List<Product>> GetByCategoryAsync(string category)
        {
            try
            {
                List<Product> products = await _repo.GetByCategoryAsync(category);
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetByCategoryBrandAsync(string category, string brand)
        {
            try
            {
                List<Product> products = await _repo.GetByCategoryBrandAsync(category, brand);
                return products;
            }
            catch( Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Product>();
            }
        }

        public async Task<List<string>> GetCategoriesAsync()
        {
            try
            {
                List<string> categories = await _repo.GetCategoriesAsync();
                return categories;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new List<string>();
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            bool status = await _repo.InsertAsync(product);
            return status;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            bool status = await _repo.UpdateAsync(product);
            return status;
        }
    }
}
