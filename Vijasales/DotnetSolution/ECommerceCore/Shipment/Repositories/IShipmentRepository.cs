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
        List<Delivery> GetAll();

        List<Delivery> GetByDate(DateTime date);

        List<Delivery> GetByStatus(string status);

        // id refers to shipment id
        bool Delete(int id);

        ShipmentDetail GetById(int shipmentId);

        bool Create(Delivery shipment);

        bool Update(Delivery shipment);


    }
}
