using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrdersProcessing.Services.ORM;
using OrdersProcessing.Entities;
using OrdersProcessing.Repositories.ORM;
using System.Web.UI.WebControls;

namespace VijaySalesAPI.Controllers
{
    [RoutePrefix("api/OrderProcessing")]
    public class OrderProcessingController : ApiController
    {
        // GET api/values

        public IEnumerable<Order> Get()
        {
            IOrderService svc = new OrderService();
            List<Order> orders = svc.GetAll();
            return orders;
        }


        public Order Get(int id) 
        {
            IOrderService svc = new OrderService(); 
            Order order= svc.GetOrder(id);
            return  order;

        }

        [HttpPost]
        public void Post([FromBody] Order o)
        {
            IOrderService svc = new OrderService(); 
            svc.Insert(o);  
            
        }

        [HttpPut]  
        public void Put(int id, [FromBody] Order o)
        {
            IOrderService svc = new OrderService(); 
            svc.Update(o);  
        }

        // DELETE api/values/5
        [HttpDelete]
        public void Delete(int id)
        {
            IOrderService svc = new OrderService(); 
            svc.Delete(id); 
        }

        [HttpGet]
        [Route("customerorders/{id}")]
        public IEnumerable<Order> GetOrders(int id) 
        {
            IOrderService svc = new OrderService();
            List<Order> orders = svc.GetCustomerOrders(id);  
            return orders;
        }

    }
}
