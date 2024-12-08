using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Repositories
{
    public interface IProductRepository
    {
       
        Task<bool> InsertAsync(Product product);
        Task<bool> UpdateAsync(Product product);

        Task<bool> DeleteAsync(int id);

        Task<int> GetCountAsync();

      
        Task<List<Product>> GetAllAsync();

        Task<Product> GetByIdAsync(int id);

        Task<List<Product>> GetByCategoryAsync(string category);
    }
}
