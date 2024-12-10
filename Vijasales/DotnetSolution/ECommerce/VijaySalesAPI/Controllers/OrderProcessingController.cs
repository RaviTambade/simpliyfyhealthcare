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
using OrdersProcessing.Models;

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


        public List<OrderList> Get(int id) 
        {
            IOrderService svc = new OrderService(); 
            OrderResponse orderResponse= svc.GetOrderDetails(id);
            return  orderResponse.OrderLists;

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

        public IEnumerable<Order> GetOrders(int id) 
        {
            IOrderService svc = new OrderService();
            List<Order> orders = svc.GetCustomerOrders(id);  
            return orders;
        }


    }
}
