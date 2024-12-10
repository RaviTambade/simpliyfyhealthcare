using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Catalog.Entities;

namespace Catalog.Repositories.ORM
{
    public class ProductContext : DbContext
    {

        private readonly string _connectionString;

        public ProductContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("Connection string is not provided.");
            }
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>((e) =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Product>().ToTable("VsProducts");
        }
    }
}



