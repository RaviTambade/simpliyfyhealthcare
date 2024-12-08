using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Services
{
    public interface IProductService
    {
       

        Task<List<Product>> GetAllAsync();
        Task<Product> GetAsync(int id);
        Task<bool> InsertAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);

        Task<List<Product>> GetByCategoryAsync(string category);
        Task<List<Product>> GetByBrandAsync(string brand);

        Task<List<Product>> GetByCategoryBrandAsync(string category, string brand);

        Task<List<string>> GetCategoriesAsync();

        Task<List<string>> GetBrandsAsync(string category);

    }
}
