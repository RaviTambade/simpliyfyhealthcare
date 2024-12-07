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
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Shipment.Repositories.ORM
{

    
    public class ShipmentRepository : IShipmentRepository
    {
        private IConfiguration _configuration;

        // Inject ShipmentContext via constructor
        public ShipmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Create(Delivery shipment)
        {
            bool status = false;
            using (var context = new ShipmentContext(_configuration))
            {
                context.Shipments.Add(shipment);
            }
            status = true;
            return status;

        }

        public bool Delete(int id)
        {
            bool flag = false;
            int ship_Id = id;
            using (var context = new ShipmentContext(_configuration))
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
        }

        public List<Delivery> GetAll()
        {
            List<Delivery> shipments = new List<Delivery>();
            using (var context = new ShipmentContext(_configuration))
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
        }

        public List<Delivery> GetByDate(DateTime date)
        {

            List<Delivery> shipments = new List<Delivery>();

            using (var context = new ShipmentContext(_configuration))
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
               
            }
        }

        public ShipmentDetail GetById(int shipmentId)
        {
            ShipmentDetail shipmentDetail = null;

            using (var context = new ShipmentContext(_configuration))
            {
                // call the stored procedure 
                // @"EXEC GetShipmentDetails @ShipmentId, @CustomerId, @OrderId"
                var query = @"EXEC GetShipmentDetails @ShipmentId";

                // Execute the stored procedure
                shipmentDetail = context.Set<ShipmentDetail>()
                    .FromSqlRaw(query,
                        new SqlParameter("@ShipmentId", (object)shipmentId))
                    .AsEnumerable() // Execute and return results
                    .FirstOrDefault();
            }

            return shipmentDetail;

        }

        public List<Delivery> GetByStatus(string status)
        {
            List<Delivery>shipments= new List<Delivery>();

            using (var context=new ShipmentContext(_configuration))
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

            
        }

        public bool Update(Delivery shipment)
        {
            bool status = false;

            using (var context = new ShipmentContext(_configuration))
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
        }
    }
}
