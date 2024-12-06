using Microsoft.AspNetCore.Mvc;
using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Services;
using Shipment.Repositories.ORM;

namespace ShipmentMVCTest.Controllers
{
    public class ShipmentsController : Controller
    {
        private IShipmentService _shipmentService;
        private ShipmentContext _context;

        public ShipmentsController(IShipmentService service) { 
            _context = new ShipmentContext();
            _shipmentService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        // list of shipments 
        public IActionResult List()
        {
            return View(_shipmentService.GetAll());
        }


        // details
        public IActionResult Details(int id)
        {
            // get the shipment using id
            return View(_shipmentService.GetById(id));
        }


    }
}
