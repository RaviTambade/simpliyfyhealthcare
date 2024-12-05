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
        bool Create(Shipment shipment);

    }
}
