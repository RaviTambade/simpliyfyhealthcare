﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Services;
using OrderProcessing.Repositories;
using OrderProcessing.Entities;
using OrderProcessing.Services.Connected;

namespace VijaySalesAPI.Controllers
{
    [Route("api/[controller]")] // The base route for the controller
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;



        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET api/orders
        [HttpGet]
        public async Task<List<Order>> GetAllOrders()
        {
            List<Order> orders = await _orderService.GetAllAsync();
            return orders;
        }

        // GET api/orders/customer/{customerId}  -> Fetch orders for a specific customer
        [HttpGet("customer/{customerId}")]
        public async Task<List<OrderList>> GetCustomerOrdersAsync(int customerId)
        {
            List<OrderList> orders = await _orderService.GetOrderDetailsAsync(customerId);
            return orders;
        }

        // GET api/orders/{id} -> Fetch a specific order by ID
        [HttpGet("{id}")]
        public async Task<Order> GetOrderById(int id)
        {
            Order order = await _orderService.GetOrderAsync(id);
            return order;
        }

        [HttpPost]
        public async Task<bool> InsertAsync(Order order)
        {
            bool status= await _orderService.InsertAsync(order);    
            return status;
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateAsync(int id,[FromBody]Order order)
        {
            return await _orderService.UpdateAsync(order);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderService.DeleteAsync(id);
        }
    }
}
