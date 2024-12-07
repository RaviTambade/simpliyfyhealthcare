using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Entities
{
    [Table("VsOrders")]
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {

            string res = string.Format("Id:{0}\nCustomerId:{1}\nOrder Date:{2}\nTotalAmount:{3}\nStatus:{4}\n", Id, CustomerId, OrderDate, TotalAmount, Status);

            return res;
        }

    }
}
