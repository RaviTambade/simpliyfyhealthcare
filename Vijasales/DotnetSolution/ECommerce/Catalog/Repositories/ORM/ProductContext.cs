using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Catalog.Entities;

namespace Catalog.Repositories.ORM
{
    public class ProductContext : DbContext
    {


        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = @"data source=shc-sql-01.database.windows.net ; database=HangFireCatalog_VG; User Id=tmgreadonly; Password=#p7P>Wzs;";
            optionsBuilder.UseSqlServer(conString);
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


