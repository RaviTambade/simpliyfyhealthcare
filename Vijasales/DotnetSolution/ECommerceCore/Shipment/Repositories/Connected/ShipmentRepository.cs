using Shipment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Repositories.Connected
{
    public class ShipmentRepository
    {

        public bool Create(Delivery shipment)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public ShipmentDetail GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Delivery> GetByStatus(string status)
        {
            throw new NotImplementedException();
        }

        public bool Update(Delivery shipment)
        {
            throw new NotImplementedException();
        }
    }
}
