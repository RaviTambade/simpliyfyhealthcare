using Microsoft.AspNetCore.Mvc;
using Shipment.Entities;

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
            List<Delivery> shipments = new List<Delivery>();
            shipments.Add(new Delivery { Id = 1, ShipmentDate = DateTime.Now, OrderId = 17, Status= "Pending" });
            shipments.Add(new Delivery { Id = 2, ShipmentDate = DateTime.Now, OrderId = 18, Status= "Pending" });
            shipments.Add(new Delivery { Id = 3, ShipmentDate = DateTime.Now, OrderId = 19, Status= "Pending" });

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
