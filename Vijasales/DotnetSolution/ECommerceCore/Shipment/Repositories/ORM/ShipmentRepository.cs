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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Shipment.Repositories.ORM
{
    public class ShipmentRepository : IShipmentRepository
    {
        private IConfiguration _configuration;

        public ShipmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateAsync(Delivery shipment)
        {
            bool status = false;
            using (var context = new ShipmentContext(_configuration))
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
            using (var context = new ShipmentContext(_configuration))
            {
                var shipment = await context.Shipments.SingleOrDefaultAsync(s => s.Id == ship_Id);
                if (shipment != null)
                {
                    context.Shipments.Remove(shipment);
                    await context.SaveChangesAsync();
                    status = true;
                }
            }
            return status;
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
           
            using (var context = new ShipmentContext(_configuration))
            {
                var dbshipments = await context.Shipments.ToListAsync();
                return dbshipments;
            }
            
        }

        public async Task<List<Delivery>> GetByDateAsync(DateTime date)
        {
            using (var context = new ShipmentContext(_configuration))
            {

                var dbShipments = await context.Shipments
                    .Where(s => s.ShipmentDate == date)
                    .ToListAsync();

                return dbShipments;

            }

        }

        public async Task<List<Delivery>> GetByDateAsync(DateTime startdate, DateTime enddate)
        {
           
            using (var context = new ShipmentContext(_configuration))
            {
                var dbShipments = await context.Shipments
                    .Where(s => s.ShipmentDate >= startdate && s.ShipmentDate <= enddate)
                    .ToListAsync();
 
                return dbShipments;
            }
        }

        public async Task<ShipmentDetail> GetByIdAsync(int shipmentId)
        {



                ShipmentDetail shipmentDetail = null;
                using (var context = new ShipmentContext(_configuration))
                {
                    // Define the stored procedure query with the necessary parameter
                    var query = @"EXEC GetShipmentDetails @ShipmentId";
                    var param = new SqlParameter("@ShipmentId", shipmentId);
                    shipmentDetail =  context.Set<ShipmentDetail>()
                               .FromSqlRaw(query, param)
                               .AsEnumerable()
                               .FirstOrDefault();
                }

                return shipmentDetail;


           
            using (var context = new ShipmentContext(_configuration))
            {
                // Define the stored procedure query with the necessary parameter
                var query = @"EXEC GetShipmentDetails @ShipmentId";
                var param = new SqlParameter("@ShipmentId", shipmentId);

                shipmentDetail = context.Set<ShipmentDetail>()
                           .FromSqlRaw(query, param)
                           .AsEnumerable()
                           .FirstOrDefault();

            }

            return shipmentDetail;


        }

        public async Task<List<ShipmentDetail>> GetByCustomerId(int customerId)
        {
            List<ShipmentDetail> shipmentDetails = null;

            using (var context = new ShipmentContext(_configuration))
            {
                var query = @"EXEC GetShipmentDetails @ShipmentId=NULL, @CustomerId=@CustomerId";

                // Create the parameters for the stored procedure
                var shipmentParam = new SqlParameter("@ShipmentId", DBNull.Value);  // Null for ShipmentId
                var customerParam = new SqlParameter("@CustomerId", customerId);    // Valid CustomerId

                // Execute the query and retrieve the shipment details
                shipmentDetails = await context.Set<ShipmentDetail>()
                                                .FromSqlRaw(query, shipmentParam, customerParam)
                                                .ToListAsync();
            }

            return shipmentDetails;
        }


        public async Task<string> GetStatusByOrderIdAsync(int orderId)
        {
            using (var context = new ShipmentContext(_configuration))
            {
                var dbShipments = await context.Shipments
                    .Where(s => s.OrderId == orderId)
                    .ToListAsync();

                return dbShipments[0]?.Status ?? "Shipment status not found.";
            }
        }

        public async Task<List<Delivery>> GetByStatusAsync(string status)
        {
            List<Delivery> shipments = new List<Delivery>();

            using (var context = new ShipmentContext(_configuration))
            {
                var dbshipments = await context.Shipments
                    .Where(s => s.Status == status).ToListAsync();
                return dbshipments;

            }


        }

        public async Task<bool> UpdateAsync(Delivery shipment)
        {
            bool status = false;

            using (var context = new ShipmentContext(_configuration))
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
                
            }

            return status;
        }

        public async Task<bool> UpdateStatusAsync(int id, string shipmentStatus)
        {
            bool status = false;
            using (var context = new ShipmentContext(_configuration))
            {
                var foundShipment = await context.Shipments.SingleOrDefaultAsync(s => s.Id == id);
                if (foundShipment != null)
                {
                    // Only update the status
                    foundShipment.Status = shipmentStatus;
                    await context.SaveChangesAsync();
                    status = true;
                }
            }
            return status;

        }
    }
}