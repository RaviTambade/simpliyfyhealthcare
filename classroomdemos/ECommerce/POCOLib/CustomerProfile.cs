using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
namespace ECommerceEntities
{
    public class CustomerProfile
    {
        public Customer TheCustomer { get; set; }
        public List<Order> OrderHistory { get; set; }
    }
}
