using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using PaymentProcessing.Entities;
using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Services;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ShipmentsController : Controller
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public List<Delivery> Get()
        {
            List<Delivery> deliveryList = _shipmentService.GetAll();

            return deliveryList;
        }

        [HttpGet("{id:int}")]
        public ShipmentDetail Get(int id)
        {
            ShipmentDetail newshipment = _shipmentService.GetById(id);
            return newshipment;
        }

        [HttpGet("{Status}")]
        public List<Delivery> GetByStatus(string status) {
            List<Delivery>deliverylistbystatus=_shipmentService.GetByStatus(status);
            return deliverylistbystatus;
        
        }
        [HttpGet("{ShipmentDate}")]
        public List<Delivery> GetByDate(DateTime date)
        {
            List<Delivery> deliverylistbydate = _shipmentService.GetByDate(date);
            return deliverylistbydate;

        }

        [HttpPost]
        public bool Insert([FromBody] Delivery delivery)
        {
            bool status = false;

            status=_shipmentService.CreateShipment(delivery);

            return status;
        }

        [HttpPut]
        public bool Update([FromBody] Delivery delivery)
        {
            bool status = false;
            
            status= _shipmentService.UpdateShipment(delivery);
            return status;

        }

        [HttpDelete("{id:int}")]
        public bool Delete(int id) { 
            bool status = false;
            status= _shipmentService.DeleteShipment(id);

            return status;
        
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
