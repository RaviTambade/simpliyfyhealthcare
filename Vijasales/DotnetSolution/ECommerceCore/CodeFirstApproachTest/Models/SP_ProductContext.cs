using System.Data.Entity;

namespace CodeFirstApproachTest.Models
{
    public class SP_ProductContext :DbContext
    {
        public SP_ProductContext() : base("DefaultConnection")
        { }

        public DbSet<SP_Product>SP_Products { get; set; }
    }
}
