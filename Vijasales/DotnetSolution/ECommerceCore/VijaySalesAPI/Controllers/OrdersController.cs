using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Services;
using OrderProcessing.Repositories;
using OrderProcessing.Entities;
using OrderProcessing.Services.Connected;
using ShoppingCart.Entities;
using OrderProcessing.Requests;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("OrderItem/{orderId}")]
        public async Task<List<OrderList>> GetOrderDetailsAsync(int orderId)
        {
            List<OrderList> orders = await _orderService.GetOrderDetailsAsync(orderId);
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
        public async Task<int> InsertAsyncint([FromBody]OrderResponse orderResponse)
        {
            int customerId = orderResponse.UserId;
            int newOrderId = await _orderService.InsertOrderAsync(customerId,orderResponse.OrderCart);    
            return newOrderId;
        }


        [HttpPut("{id}")]
        public async Task<bool> UpdateAsync(int id,[FromBody]Order order)
        {
            return await _orderService.UpdateOrderAsync(order);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderService.DeleteAsync(id);
        }
        [HttpGet("Customer/{customerId}")]
        [Authorize]
        public async Task<List<OrderList>> GetCustomerPastOrders(int customerId)
        {
            List<OrderList> orders = await _orderService.GetCustomerOrdersAsync(customerId);
            return orders;
        }
    }
}
