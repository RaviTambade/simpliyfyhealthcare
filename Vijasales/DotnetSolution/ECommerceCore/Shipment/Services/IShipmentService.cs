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
        bool CreateShipment(Delivery shipment);

        bool UpdateShipment(Delivery shipment);

        bool DeleteShipment(int id);

        List<Delivery> GetAll();

        List<Delivery> GetByDate(DateTime date);

        List<Delivery> GetByStatus(string status);

        Delivery GetById(int id);

    }
}
