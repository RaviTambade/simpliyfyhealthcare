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
        private readonly ShipmentContext _context;
        private readonly IConfiguration _configuration;

        public ShipmentService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CreateShipment(Delivery shipment)
        {
            return false;
        }

        public bool DeleteShipment(int id)
        {
            return false;
        }

        public List<Delivery> GetAll()
        {
            IShipmentRepository repo = new ShipmentRepository(_configuration);

            return repo.GetAll();
        }

        public List<Delivery> GetByDate(DateTime date)
        {
            return null;
        }

        public ShipmentDetail GetById(int shipmentId)
        {
            IShipmentRepository repo = new ShipmentRepository(_configuration);
            return repo.GetById(shipmentId);
        }

        public List<Delivery> GetByStatus(string status)
        {
            return null;
        }

        public bool UpdateShipment(Delivery shipment)
        {
            return false;
        }
    }
}
