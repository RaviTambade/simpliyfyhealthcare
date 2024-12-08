using Shipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Services
{
    public interface IShipmentService
    {
        Task<bool> CreateShipmentAsync(Delivery shipment);

        Task<bool> UpdateShipmentAsync(Delivery shipment);

        Task<bool> DeleteShipmentAsync(int id);

        Task<List<Delivery>> GetAllAsync();

        Task<List<Delivery>> GetByDateAsync(DateTime date);

        Task<List<Delivery>> GetByStatusAsync(string status);

        Task<ShipmentDetail> GetByIdAsync(int id);

    }
}
