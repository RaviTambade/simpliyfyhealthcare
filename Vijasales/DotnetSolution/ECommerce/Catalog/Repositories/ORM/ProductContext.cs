using System.Collections.Generic;
using System.Reflection.Emit;
using System.Data.Entity;
using Catalog.Entities;

namespace Catalog.Repositories.ORM
{
  public class ECommerceContext : DbContext
{
     public DbSet<Product> Products { get; set; }
     public ECommerceContext() : base("name=conString") { }
}
}


