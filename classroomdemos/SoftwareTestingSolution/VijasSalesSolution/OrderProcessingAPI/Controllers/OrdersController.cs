using Transflower.MembershipRolesMgmt.Helpers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderProcessing.Entities;
using OrderProcessing.Repositories;

namespace OrderProcessingAPI.Controllers
{
    [Authorize]
    // [Authorize("Director")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
    
        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            _logger.Log(LogLevel.Information,"Get Method is called.");
            List<Order> orders = OrderManager.GetAll();
            return orders;
        }


        [HttpGet("{id}")]
        public Order GetById(int id)
        {
            _logger.Log(LogLevel.Information, "GetById Method is called.");
            Order theOrder = OrderManager.GetById(id);
            return theOrder;
        }
    }
}
