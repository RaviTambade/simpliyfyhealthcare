using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Entities
{
    public class PaymentData
    {
        public int OrderId { get; set; }
        public string AccountNumber { get; set; }
        public string PaymentMethod { get; set; }
    }
}
