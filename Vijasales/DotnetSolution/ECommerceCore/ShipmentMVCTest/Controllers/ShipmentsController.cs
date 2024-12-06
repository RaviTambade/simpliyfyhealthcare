using Microsoft.AspNetCore.Mvc;
using ShipmentLib.Entities;

namespace ShipmentMVCTest.Controllers
{
    public class ShipmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // list of shipments 
        public IActionResult List()
        {
            List<Shipment> shipments = new List<Shipment>();
            shipments.Add(new Shipment { Id = 1, ShipmentDate = DateTime.Now, OrderId = 17, ShipmentStatus = "Pending" });
            shipments.Add(new Shipment { Id = 2, ShipmentDate = DateTime.Now, OrderId = 18, ShipmentStatus = "Pending" });
            shipments.Add(new Shipment { Id = 3, ShipmentDate = DateTime.Now, OrderId = 19, ShipmentStatus = "Pending" });

            return View(shipments);
        }


        // details
        public IActionResult Details(int id)
        {
            // get the shipment using id

            return View();
        }


    }
}
