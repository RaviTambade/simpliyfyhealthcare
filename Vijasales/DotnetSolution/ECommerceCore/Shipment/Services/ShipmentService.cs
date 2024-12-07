using Shipment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Shipment.Repositories.ORM;
using Shipment.Repositories;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace Shipment.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly IConfiguration _configuration;
        private readonly IShipmentRepository _repo;

        public ShipmentService(IConfiguration configuration)
        {
            _configuration = configuration;
            _repo = new ShipmentRepository(configuration);
        }

        public bool CreateShipment(Delivery shipment)
        {
            if(_repo.Create(shipment))
            {
                return true;
            }
            return false;
        }

        public bool DeleteShipment(int id)
        {
            if (_repo.Delete(id))
            {
                return true;
            }
            return false;
        }

        public List<Delivery> GetAll()
        {
            return _repo.GetAll();
        }

        public List<Delivery> GetByDate(DateTime date)
        {
            return _repo.GetByDate(date);
        }

        public ShipmentDetail GetById(int shipmentId)
        {
            return _repo.GetById(shipmentId);
        }

        public List<Delivery> GetByStatus(string status)
        {
            return _repo.GetByStatus(status);
        }

        public bool UpdateShipment(Delivery shipment)
        {
            if (_repo.Update(shipment))
            {
                return true;
            }
            return false;
        }
    }
}
