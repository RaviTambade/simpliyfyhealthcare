using Shipment.Entities;
using Shipment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipment.Entities;
using Shipment.Repositories.ORM;

namespace Shipment.Services
{
    
    public class ShipmentService:IShipmentService
    {
        IShipmentRepository _repo = new ShipmentRepository();
        public async Task<bool> CreateShipmentAsync(Delivery shipment)
        {
            if (await _repo.CreateAsync(shipment))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteShipmentAsync(int id)
        {
            if (await _repo.DeleteAsync(id))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Delivery>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<List<Delivery>> GetByDateAsync(DateTime date)
        {
            return await _repo.GetByDateAsync(date);
        }

        public async Task<ShipmentDetail> GetByIdAsync(int shipmentId)
        {
            return await _repo.GetByIdAsync(shipmentId);
        }

        public async Task<List<Delivery>> GetByStatusAsync(string status)
        {
            return await _repo.GetByStatusAsync(status);
        }
        public async Task<string> GetStatusByOrderIdAsync(int orderId)
        {
            return await _repo.GetStatusByOrderIdAsync(orderId);
        }

        public async Task<List<Delivery>> GetByDateAsync(DateTime startdate, DateTime enddate)
        {
            return await _repo.GetByDateAsync(startdate, enddate);
        }

        public async Task<bool> UpdateShipmentAsync(Delivery shipment)
        {
            if (await _repo.UpdateAsync(shipment))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateShipmentStatusAsync(int id, string shipmentStatus)
        {
            if (await _repo.UpdateStatusAsync(id,shipmentStatus))
            {
                return true;
            }
            return false;
        }
    }
}
