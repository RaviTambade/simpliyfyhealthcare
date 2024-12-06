using Microsoft.AspNetCore.Mvc;
using ShipmentMVCTest.Models;
using System.Diagnostics;
using Shipment.Entities;

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
            List<Delivery>shipments = new List<Delivery>();
            shipments.Add(new Delivery { Id=1,  ShipmentDate=DateTime.Now,OrderId=17,Status="Pending"});
            shipments.Add(new Delivery { Id=2,  ShipmentDate=DateTime.Now,OrderId=18,Status="Delivered"});
            shipments.Add(new Delivery { Id=3,  ShipmentDate=DateTime.Now,OrderId=19,Status="Rejected"});
            shipments.Add(new Delivery { Id=4,  ShipmentDate=DateTime.Now,OrderId=20,Status="Delivered"});

            return View(shipments);
        }
    }
}
