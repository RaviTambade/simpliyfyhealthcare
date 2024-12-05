using ShipmentLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipmentLib.Repositories
{
    public interface IShipmentRepository
    {
        List<Shipment> GetAll();

        List<Shipment> GetByDate(DateTime date);

        List<Shipment> GetByStatus(string status);

        // id refers to shipment id
        bool Delete(int id);

        Shipment GetById(int id);

        bool Create(Shipment shipment);

        bool Update(Shipment shipment);


    }
}
