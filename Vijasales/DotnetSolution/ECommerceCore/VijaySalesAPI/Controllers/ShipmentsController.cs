﻿using Catalog.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
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

        [HttpGet("status/{Status}")]
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

        [HttpGet("{id:int}")]
        public async Task<ShipmentDetail> Get(int id)
        {
            return await _shipmentService.GetByIdAsync(id);
        }


        //  /api/shipments/order/{id}
        [HttpGet("order/{orderId:int}")]
        public async Task<IActionResult> GetOrderDeliveryStatus(int orderId)
        {
            string status = await _shipmentService.GetStatusByOrderIdAsync(orderId);
            //var obj = new
            //{
            //    orderId = orderId,
            //    status = status,
            //};
            return Ok(status);
        }

        [HttpGet("customer/{customerId:int}")]
        public async Task<IActionResult> GetShipmentsByCustomerId(int customerId)
        {
            List<ShipmentDetail> list = await _shipmentService.GetByCustomerId(customerId);
            return Ok(list);
        }


        [HttpGet("date/{filterDate}")]
        public async Task<IActionResult> GetByDate(string filterDate)
        {
            DateTime date;
            if (!DateTime.TryParse(filterDate, out date))
            {
                return BadRequest("Invalid date format.");
            }

            List<Delivery> deliverylistbydate = await _shipmentService.GetByDateAsync(date);
            return Ok(deliverylistbydate);
        }

        [HttpGet("dates/{startDate}/{endDate}")]
        public async Task<IActionResult> GetByDate(string startDate,string endDate)
        {
            DateTime date1,date2;

           
            if ((!DateTime.TryParse(startDate, out date1) || (!DateTime.TryParse(endDate, out date2))))
            {
                return BadRequest("Invalid date format.");
            }

            List<Delivery> deliverylistbydaterange = await _shipmentService.GetByDateAsync(date1,date2);
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

        [HttpPut("updateStatus/{id:int}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] string status)
        {
            if (await _shipmentService.UpdateShipmentStatusAsync(id, status))
            {
                return Ok("Update success");
            }

            return BadRequest("Update failed");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id) { 
            bool status = false;
            status = await _shipmentService.DeleteShipmentAsync(id);

            return Ok(status);
        }

    }
}
