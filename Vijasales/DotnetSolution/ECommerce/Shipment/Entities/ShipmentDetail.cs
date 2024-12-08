using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Entities
{
    public class ShipmentDetail
    {
        // shiping details- user name and address, items, amount

        public int ShipmentId { get; set; }

        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryStatus { get; set; }

    }
}
