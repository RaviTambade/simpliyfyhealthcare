using ShoppingCart.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Requests
{
    public class OrderResponse
    {
        public int UserId { get; set; }
        public Cart OrderCart { get; set; }
    }
}
