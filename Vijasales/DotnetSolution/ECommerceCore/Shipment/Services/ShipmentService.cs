using Shipment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Shipment.Repositories.ORM;

namespace ShipmentLib.Services
{
    public class ShipmentService : IShipmentService
    {
        private readonly ShipmentContext _context;

        public ShipmentService(ShipmentContext context)
        {
            _context = context;
        }

        public bool CreateShipment(Delivery shipment)
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

        public List<Delivery> GetAll()
        {
            try
            {
                return _context.Shipments.ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public List<Delivery> GetByDate(DateTime date)
        {
            try
            {
                return _context.Shipments
                               .Where(s => s.ShipmentDate.Date == date.Date)
                               .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public Delivery GetById(int id)
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

        public List<Delivery> GetByStatus(string status)
        {
            try
            {
                return _context.Shipments
                               .Where(s => s.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                               
                               .ToList();
            }
            catch (Exception)
            {
                return new List<Delivery>();
            }
        }

        public bool UpdateShipment(Delivery shipment)
        {
            try
            {
                var existingShipment = _context.Shipments.Find(shipment.Id);
                if (existingShipment == null)
                    return false;

                existingShipment.ShipmentDate = shipment.ShipmentDate;
                existingShipment.Status = shipment.Status;

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
