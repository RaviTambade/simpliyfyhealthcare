using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public double TotalAmount { get; set; }
    }
}
