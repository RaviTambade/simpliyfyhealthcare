using Shipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Repositories
{
    public interface IShipmentRepository
    {
        Task<List<Delivery>> GetAllAsync();

        Task<List<Delivery>> GetByDateAsync(DateTime date);

        Task<List<Delivery>> GetByStatusAsync(string status);

        // id refers to shipment id
        Task<bool> DeleteAsync(int id);

        Task<ShipmentDetail> GetByIdAsync(int shipmentId);

        Task<string> GetStatusByOrderIdAsync(int orderId);

        Task<List<ShipmentDetail>> GetByCustomerId(int customerId);

        Task<bool> CreateAsync(Delivery shipment);

        Task<bool> UpdateAsync(Delivery shipment);

        Task<bool> UpdateStatusAsync(int id,  string status);

         Task<List<Delivery>> GetByDateAsync(DateTime startdate, DateTime enddate);

    }
}
