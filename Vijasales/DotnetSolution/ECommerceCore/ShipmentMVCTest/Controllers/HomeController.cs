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
            shipments.Add(new Shipment { Id=2,  ShipmentDate=DateTime.Now,OrderId=18,ShipmentStatus="Pending"});
            shipments.Add(new Shipment { Id=3,  ShipmentDate=DateTime.Now,OrderId=19,ShipmentStatus="Pending"});

            return View(shipments);
        }
    }
}
