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
    }
}
