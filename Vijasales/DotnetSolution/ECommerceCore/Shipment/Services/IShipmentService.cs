using ShipmentLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentLib.Services
{
    public interface IShipmentService
    {
        bool CreateShipment(Shipment shipment);

        bool UpdateShipment(Shipment shipment);

        bool DeleteShipment(int id);

        List<Shipment> GetAll();

        List<Shipment> GetByDate(DateTime date);

        List<Shipment> GetByStatus(string status);

        Shipment GetById(int id);

    }
}
