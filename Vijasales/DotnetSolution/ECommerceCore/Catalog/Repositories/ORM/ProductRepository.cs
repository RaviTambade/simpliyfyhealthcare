﻿using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.EntityFrameworkCore;
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
            using (var ctx = new ProductContext())
            {
                var products =await  ctx.Products.ToListAsync();
                 return products;
            }
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            using (var ctx = new ProductContext())
            {
                var product = await ctx.Products.FindAsync(id);
                return product;
            }
        }

        public async Task<bool> InsertAsync(Product product)
        {
            bool status = false;
            using (var ctx = new ProductContext())
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
            using (var ctx = new ProductContext())
            {
                ctx.Products.Remove(await ctx.Products.FindAsync(Id));
               await ctx.SaveChangesAsync();
                status = true;
            }
            return status;
        }

        public async Task <bool> UpdateAsync(Product product)
        {
            bool status = false;
            using (var ctx = new ProductContext())
            {

               ctx.Products.Update(product);
              await ctx.SaveChangesAsync();
                status = true;
            }
            return status;
        }
        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetByCategoryAsync(string category)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var products = await ctx.Products
                                             .Where(p => p.Category == category)
                                             .ToListAsync();
                    return products;
                }
            }
            catch(Exception ex)
            {
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetByBrandAsync(string brand)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var products = await ctx.Products
                                             .Where(p => p.Brand == brand)
                                             .ToListAsync();
                    return products;
                }
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }

        public async Task<List<Product>> GetByCategoryBrandAsync(string category,string brand)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var products = await ctx.Products
                                             .Where(p => p.Category == category && p.Brand == brand)
                                             .ToListAsync();
                    return products;
                }
            }
            catch (Exception ex)
            {
                return new List<Product>();
            }
        }


    }
}
