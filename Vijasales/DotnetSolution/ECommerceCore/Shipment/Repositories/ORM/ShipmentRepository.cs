using Shipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using Microsoft.EntityFrameworkCore;

namespace Shipment.Repositories.ORM
{

    public class ShipmentContext : DbContext
    {
        public DbSet<Delivery> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Add constring here to run  (@-------)
            string conString = "Not added because of Security Issues";
            optionsBuilder.UseSqlServer(conString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Delivery>((e) =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Delivery>().ToTable("VsShipments");
        }

        
    }
    public class ShipmentRepository : IShipmentRepository
    {
        public bool Create(Delivery shipment)
        {
            bool status = false;
            using (var context = new ShipmentContext())
            {
                context.Shipments.Add(shipment);
            }
            status = true;
            return status;


           // throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool flag = false;
            int ship_Id = id;
            using (var context = new ShipmentContext())
            {
                var shipment = context.Shipments.SingleOrDefault(s => s.Id == ship_Id);
                if (shipment != null)
                {
                    context.Shipments.Remove(shipment);
                    context.SaveChanges();

                }
                else
                {
                    Console.WriteLine("Shipment not found.");
                }
                flag = true;
            }

            return flag;

           // throw new NotImplementedException();
        }

        public List<Delivery> GetAll()
        {
            List<Delivery> shipments = new List<Delivery>();
            using (var context = new ShipmentContext())
            {
                var dbshipments = context.Shipments.ToList();
                foreach (var shipment in dbshipments)
                {
                    Delivery theShipment = new Delivery();
                    theShipment.Id = shipment.Id;
                    theShipment.OrderId = shipment.OrderId;
                    theShipment.ShipmentDate=shipment.ShipmentDate;
                    theShipment.Status=shipment.Status;
                    
                    shipments.Add(theShipment);
                }
            }
            return shipments;
            //throw new NotImplementedException();
        }

        public List<Delivery> GetByDate(DateTime date)
        {

            List<Delivery> shipments = new List<Delivery>();

            using (var context = new ShipmentContext())
            {
                var dbshipments = context.Shipments.ToList();

                foreach (var shipment in dbshipments)
                {
                    Delivery theShipment = new Delivery();
                    if (shipment.ShipmentDate == date)
                    {
                        theShipment.Id = shipment.Id;
                        theShipment.OrderId = shipment.OrderId;
                        theShipment.ShipmentDate = shipment.ShipmentDate;
                        theShipment.Status = shipment.Status;

                        shipments.Add(theShipment);
                    }

                }
                return shipments;
                //throw new NotImplementedException();
            }
        }

        public Delivery GetById(int id)
        {
            Delivery shipment = null;
            int ship_Id = id;
            using (var context = new ShipmentContext())
            {
                shipment = context.Shipments.SingleOrDefault(s => s.Id == ship_Id);

            }
            return shipment;

            //throw new NotImplementedException();
        }

        public List<Delivery> GetByStatus(string status)
        {
            List<Delivery>shipments= new List<Delivery>();

            using (var context=new ShipmentContext())
            {
              var  dbshipments = context.Shipments.ToList();

                foreach (var shipment in dbshipments)
                {
                    Delivery theShipment = new Delivery();
                    if(shipment.Status==status)
                    {
                        theShipment.Id = shipment.Id;
                        theShipment.OrderId = shipment.OrderId;
                        theShipment.ShipmentDate = shipment.ShipmentDate;
                        theShipment.Status = shipment.Status;

                        shipments.Add(theShipment);
                    }
                    
                }

                return shipments;

            }

            throw new NotImplementedException();
        }

        public bool Update(Delivery shipment)
        {
            bool status = false;

            using (var context = new ShipmentContext())
            {
                var foundShipment = context.Shipments.SingleOrDefault(s => s.Id == shipment.Id);
                if (foundShipment != null)
                {
                    foundShipment.ShipmentDate = shipment.ShipmentDate;
                    foundShipment.Status = shipment.Status;
                    foundShipment.OrderId = shipment.OrderId;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Shipment not found.");
                }
                status = true;
            }


            return status;
           // throw new NotImplementedException();
        }
    }
}
