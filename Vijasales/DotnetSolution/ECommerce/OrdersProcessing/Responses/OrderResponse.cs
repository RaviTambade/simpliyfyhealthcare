using OrdersProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersProcessing.Models
{
    public class OrderResponse
    {
       public List<OrderList> OrderLists { get; set; }
        public OrderResponse()
        {
            OrderLists = new List<OrderList>();
        }


    }
}
