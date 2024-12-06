using ShipmentLib.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentLib.Repositories.ORM;

namespace ShipmentLib.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly ShipmentContext _context;

        public ShipmentService(ShipmentContext context)
        {
            _context = context;
        }

        public bool CreateShipment(Shipment shipment)
        {
            try
            {
                if (shipment == null)
                    return false;

                _context.Shipments.Add(shipment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteShipment(int id)
        {
            try
            {
                var shipment = _context.Shipments.Find(id);
                if (shipment == null)
                    return false;

                _context.Shipments.Remove(shipment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Shipment> GetAll()
        {
            try
            {
                return _context.Shipments.ToList();
            }
            catch (Exception)
            {
                return new List<Shipment>();
            }
        }

        public List<Shipment> GetByDate(DateTime date)
        {
            try
            {
                return _context.Shipments
                               .Where(s => s.ShipmentDate.Date == date.Date)
                               .ToList();
            }
            catch (Exception)
            {
                return new List<Shipment>();
            }
        }

        public Shipment GetById(int id)
        {
            try
            {
                return _context.Shipments.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Shipment> GetByStatus(string status)
        {
            try
            {
                return _context.Shipments
                               .Where(s => s.ShipmentStatus.Equals(status, StringComparison.OrdinalIgnoreCase))
                               
                               .ToList();
            }
            catch (Exception)
            {
                return new List<Shipment>();
            }
        }

        public bool UpdateShipment(Shipment shipment)
        {
            try
            {
                var existingShipment = _context.Shipments.Find(shipment.Id);
                if (existingShipment == null)
                    return false;

                existingShipment.ShipmentDate = shipment.ShipmentDate;
                existingShipment.ShipmentStatus = shipment.ShipmentStatus;

                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
