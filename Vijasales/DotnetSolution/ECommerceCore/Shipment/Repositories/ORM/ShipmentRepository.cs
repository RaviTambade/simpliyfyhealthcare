﻿using ShipmentLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace ShipmentLib.Repositories.ORM
{

    public class ShipmentContext : DbContext
    {
        public DbSet<Shipment> Shipments { get; set; }
        public ShipmentContext() : base("name=conString") { }
    }
    public class ShipmentRepository : IShipmentRepository
    {
        public bool Create(Shipment shipment)
        {

            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Shipment> GetAll()
        {
            List<Shipment> shipments = new List<Shipment>();
            using (var context = new ShipmentContext())
            {
                var dbshipments = context.Shipments.ToList();
                foreach (var shipment in dbshipments)
                {
                    Shipment theShipment = new Shipment();
                    theShipment.Id = shipment.Id;
                    theShipment.OrderId = shipment.OrderId;
                    theShipment.ShipmentDate=shipment.ShipmentDate;
                    theShipment.ShipmentStatus=shipment.ShipmentStatus;
                    
                    shipments.Add(theShipment);
                }
            }
            return shipments;
            //throw new NotImplementedException();
        }

        public List<Shipment> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Shipment GetById(int id)
        {
            Shipment shipment = null;
            int ship_Id = id;
            using (var context = new ShipmentContext())
            {
                shipment = context.Shipments.SingleOrDefault(s => s.Id == ship_Id);

            }
            return shipment;

            //throw new NotImplementedException();
        }

        public List<Shipment> GetByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public bool Update(Shipment shipment)
        {
            bool status = false;

            using (var context = new ShipmentContext())
            {
                var foundShipment = context.Shipments.SingleOrDefault(s => s.Id == shipment.Id);
                if (foundShipment != null)
                {
                    foundShipment.ShipmentDate = shipment.ShipmentDate;
                    foundShipment.ShipmentStatus = shipment.ShipmentStatus;
                    foundShipment.OrderId = shipment.OrderId;

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Shipment not found.");
                }
            }


            return status;
           // throw new NotImplementedException();
        }
    }
}
