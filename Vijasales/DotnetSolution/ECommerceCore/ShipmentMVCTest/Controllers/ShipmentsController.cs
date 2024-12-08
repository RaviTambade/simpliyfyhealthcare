using Microsoft.AspNetCore.Mvc;
using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Services;
using Shipment.Repositories.ORM;

namespace ShipmentMVCTest.Controllers
{
    public class ShipmentsController : Controller
    {
        private readonly IShipmentService _shipmentService;

        // Constructor to inject IShipmentService
        public ShipmentsController(IShipmentService service)
        {
            _shipmentService = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        // list of shipments 
        public IActionResult List()
        {
            return View(_shipmentService.GetAllAsync());
        }


        // details
        public IActionResult Details(int id)
        {
            // get the shipment using id
            return View(_shipmentService.GetByIdAsync(id));
        }


    }
}
