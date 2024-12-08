using Catalog.Entities;
using Catalog.Repositories;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Repositories.ORM
{
    public class  ProductRepository:IProductRepository
    {
        public async Task<List<Product>> GetAllAsync()
        {
            using (var ctx = new ECommerceContext())
            {
                var products = await ctx.Products.ToListAsync();
                return products;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (var ctx = new ECommerceContext())
            {
                var product = await ctx.Products.FindAsync(id);
                return product;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            bool status = false;
            using (var ctx = new ECommerceContext())
            {
                ctx.Products.Add(product);
               await ctx.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            bool status = false;
            using (var ctx = new ECommerceContext())
            {
                ctx.Products.Remove(await ctx.Products.FindAsync(Id));
               await ctx.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            bool status = false;
            using (var ctx = new ECommerceContext())
            {
                // Attach the entity to the context if it's not already tracked
                ctx.Products.Attach(product);

                // Mark the entity as modified
                ctx.Entry(product).State = EntityState.Modified;

                // Save changes to the database
                await ctx.SaveChangesAsync();

                status = true;
            }
            return status;
        }
        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetByCategoryAsync(string category)
        {
            throw new NotImplementedException();
        }
    }
}
