using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Services;
using System.Web.Http.Cors;
using Shipment.Repositories;
using Shipment.Services;

namespace VijaySalesSOA.Controllers
{
    //[Route("api/shipments")]

    [EnableCors(origins: "http://localhost:49997", headers: "*", methods: "*")]

    public class ShipmentsController : ApiController
    {
        IShipmentService _shipmentService = new ShipmentService();
        
        

        [HttpGet]
        public async Task<List<Delivery>> GetByStatus(string status)
        {
            List<Delivery> deliverylistbystatus = await _shipmentService.GetByStatusAsync(status);
            return deliverylistbystatus;
        }

        [HttpGet]
        public async Task<List<Delivery>> GetAll()
        {
            List<Delivery> deliveryList = await _shipmentService.GetAllAsync();

            return deliveryList;
        }

        [HttpGet]
        public async Task<ShipmentDetail> Get(int id)
        {
            return await _shipmentService.GetByIdAsync(id);
        }


        
        [HttpGet]
        public async Task<IHttpActionResult> GetOrderDeliveryStatus(int orderId)
        {
            string status = await _shipmentService.GetStatusByOrderIdAsync(orderId);
            var obj = new
            {
                orderId = orderId,
                status = status,
            };
            return Ok(obj);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetByDate(string filterDate)
        {
            DateTime date;
            if (!DateTime.TryParse(filterDate, out date))
            {
                return BadRequest("Invalid date format.");
            }

            List<Delivery> deliverylistbydate = await _shipmentService.GetByDateAsync(date);
            return Ok(deliverylistbydate);

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetByDate(string startDate, string endDate)
        {
            DateTime date1, date2;


            if ((!DateTime.TryParse(startDate, out date1) || (!DateTime.TryParse(endDate, out date2))))
            {
                return BadRequest("Invalid date format.");
            }

            List<Delivery> deliverylistbydaterange = await _shipmentService.GetByDateAsync(date1, date2);
            return Ok(deliverylistbydaterange);

        }

        [HttpPost]
        public async Task<bool> Insert([FromBody] Delivery delivery)
        {
            bool status = false;

            status = await _shipmentService.CreateShipmentAsync(delivery);

            return status;
        }

        // api/shipments/
        [HttpPut]
        public async Task<bool> Update([FromBody] Delivery delivery)
        {
            bool status = false;

            status = await _shipmentService.UpdateShipmentAsync(delivery);
            return status;
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            if (await _shipmentService.UpdateShipmentStatusAsync(id, status))
            {
                return Ok("Update success");
            }

            return BadRequest("Update failed");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            bool status = false;
            status = await _shipmentService.DeleteShipmentAsync(id);

            return Ok(status);
        }
    }
}
