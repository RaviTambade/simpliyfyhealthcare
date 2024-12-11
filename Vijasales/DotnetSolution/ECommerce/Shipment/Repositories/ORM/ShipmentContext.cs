using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Shipment;
using Shipment.Entities;

namespace Shipment.Repositories.ORM
{
    public class ShipmentContext : DbContext
    {
        public DbSet<Delivery> Shipments { get; set; }

        public ShipmentContext() : base("name=conString") { }

    }
}
