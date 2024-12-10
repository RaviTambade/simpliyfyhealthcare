using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipment.Entities;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Shipment.Repositories.ORM
{
    public class ShipmentRepository : IShipmentRepository
    {
        public async Task<bool> CreateAsync(Delivery shipment)
        {
            bool status = false;
            using (var context = new ShipmentContext())
            {
                context.Shipments.Add(shipment);
                await context.SaveChangesAsync();
                status = true;
            }
            return status;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            int ship_Id = id;
            using (var context = new ShipmentContext())
            {
                var shipment = await context.Shipments.SingleOrDefaultAsync(s => s.Id == ship_Id);
                if (shipment != null)
                {
                    context.Shipments.Remove(shipment);
                    await context.SaveChangesAsync();
                    status = true;
                }
                else
                {
                    Console.WriteLine("Shipment not found.");
                }
            }

            return status;
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
            //// changes needed
            List<Delivery> shipments = new List<Delivery>();
            using (var context = new ShipmentContext())
            {
                var dbshipments = await context.Shipments.ToListAsync();
                foreach (var shipment in dbshipments)
                {
                    Delivery theShipment = new Delivery();
                    theShipment.Id = shipment.Id;
                    theShipment.OrderId = shipment.OrderId;
                    theShipment.ShipmentDate = shipment.ShipmentDate;
                    theShipment.Status = shipment.Status;

                    shipments.Add(theShipment);
                }
            }
            return shipments;
        }

        public async Task<List<Delivery>> GetByDateAsync(DateTime date)
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

            }
        }

        public async Task<List<Delivery>> GetByDateAsync(DateTime startdate, DateTime enddate)
        {
            List<Delivery> shipments = new List<Delivery>();

            using (var context = new ShipmentContext())
            {
                // Query to get shipments within the date range
                var dbShipments = await context.Shipments
                    .Where(s => s.ShipmentDate >= startdate && s.ShipmentDate <= enddate)
                    .ToListAsync();

                foreach (var shipment in dbShipments)
                {
                    // Mapping the shipment to Delivery object
                    Delivery theShipment = new Delivery
                    {
                        Id = shipment.Id,
                        OrderId = shipment.OrderId,
                        ShipmentDate = shipment.ShipmentDate,
                        Status = shipment.Status
                    };

                    shipments.Add(theShipment);
                }
            }

            return shipments;
        }

        public async Task<ShipmentDetail> GetByIdAsync(int shipmentId)
        {
            ShipmentDetail shipmentDetail = null;
            using (var context = new ShipmentContext())
            {
                // Define the stored procedure query with the necessary parameter
                var query = @"EXEC GetShipmentDetails @ShipmentId";

                var param = new SqlParameter("@ShipmentId", shipmentId);

                var results = await context.Database.SqlQuery<ShipmentDetail>(query, param).ToListAsync();

                shipmentDetail = results.FirstOrDefault();
            }

            return shipmentDetail;
        }

        public async Task<string> GetStatusByOrderIdAsync(int orderId)
        {
            ShipmentDetail shipmentDetail = null;
            using (var context = new ShipmentContext())
            {
                var query = @"EXEC GetShipmentDetails @OrderId";

                var param = new SqlParameter("@OrderId", orderId);

                var results = await context.Database.SqlQuery<ShipmentDetail>(query, param).ToListAsync();

                shipmentDetail = results.FirstOrDefault();
            }

            return shipmentDetail.DeliveryStatus;
        }


            public async Task<List<Delivery>> GetByStatusAsync(string status)
        {
            List<Delivery> shipments = new List<Delivery>();

            using (var context = new ShipmentContext())
            {
                var dbshipments = await context.Shipments.ToListAsync();

                foreach (var shipment in dbshipments)
                {
                    Delivery theShipment = new Delivery();
                    if (shipment.Status == status)
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

        public async Task<bool> UpdateAsync(Delivery shipment)
        {
            bool status = false;

            using (var context = new ShipmentContext())
            {
                var foundShipment = await context.Shipments.SingleOrDefaultAsync(s => s.Id == shipment.Id);
                if (foundShipment != null)
                {
                    foundShipment.ShipmentDate = shipment.ShipmentDate;
                    foundShipment.Status = shipment.Status;
                    foundShipment.OrderId = shipment.OrderId;

                    await context.SaveChangesAsync();
                    status = true;
                }
                else
                {
                    Console.WriteLine("Shipment not found.");
                }
            }


            return status;
        }


    }
}
