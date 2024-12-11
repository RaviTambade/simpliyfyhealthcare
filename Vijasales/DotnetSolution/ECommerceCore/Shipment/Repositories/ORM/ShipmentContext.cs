using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Repositories.ORM
{
    public class ShipmentContext : DbContext
    {
        private readonly string _connectionString;
        public ShipmentContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
           
        }
        public DbSet<Delivery> Shipments { get; set; }
        public DbSet<ShipmentDetail> ShipmentDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Delivery>((e) =>
            {
                e.HasKey(e => e.Id);
            });

            modelBuilder.Entity<ShipmentDetail>()
                .HasNoKey();

            modelBuilder.Entity<Delivery>().ToTable("VsShipments");
        }


    }
}
