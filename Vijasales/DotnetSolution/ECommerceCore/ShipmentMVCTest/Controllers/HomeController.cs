using Microsoft.AspNetCore.Mvc;
using ShipmentMVCTest.Models;
using System.Diagnostics;
using ShipmentLib.Entities;

namespace ShipmentMVCTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult VendorView()
        {
            List<Shipment>shipments = new List<Shipment>();
            shipments.Add(new Shipment { Id=1,  ShipmentDate=DateTime.Now,OrderId=17,ShipmentStatus="Pending"});
            shipments.Add(new Shipment { Id=2,  ShipmentDate=DateTime.Now,OrderId=18,ShipmentStatus="Delivered"});
            shipments.Add(new Shipment { Id=3,  ShipmentDate=DateTime.Now,OrderId=19,ShipmentStatus="Rejected"});
            shipments.Add(new Shipment { Id=4,  ShipmentDate=DateTime.Now,OrderId=20,ShipmentStatus="Delivered"});

            return View(shipments);
        }
    }
}
