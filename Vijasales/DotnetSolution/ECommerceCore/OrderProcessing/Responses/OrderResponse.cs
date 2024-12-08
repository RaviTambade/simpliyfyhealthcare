using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Responses
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
