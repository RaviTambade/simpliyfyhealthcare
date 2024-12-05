using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceEntities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public double Amount { get; set; }  

        public string Status {  get; set; }
    }
}