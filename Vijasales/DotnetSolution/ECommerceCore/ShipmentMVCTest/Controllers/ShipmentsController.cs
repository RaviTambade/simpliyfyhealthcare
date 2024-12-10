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
        public async Task<IActionResult> List()
        {
            // DateTime startdate = new DateTime(2024, 12, 8);
            // DateTime enddate = new DateTime(2024, 12, 14);
            // return View(await _shipmentService.GetByDateAsync(startdate,enddate));
            return View(await _shipmentService.GetByStatusAsync("Pending"));
        }


        // details
        public async Task<IActionResult> Details(int id)
        {
            // get the shipment using id
            return View(await _shipmentService.GetByIdAsync(id));
        }



    }
}
