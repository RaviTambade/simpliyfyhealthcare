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
    }
}
