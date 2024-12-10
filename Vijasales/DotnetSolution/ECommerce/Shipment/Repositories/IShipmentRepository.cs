using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipment.Entities;
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

        Task<bool> CreateAsync(Delivery shipment);

        Task<bool> UpdateAsync(Delivery shipment);

        Task<List<Delivery>> GetByDateAsync(DateTime startdate, DateTime enddate);

        Task<string> GetStatusByOrderIdAsync(int orderId);

        Task<bool> UpdateStatusAsync(int id, string shipmentStatus);
    }
}
