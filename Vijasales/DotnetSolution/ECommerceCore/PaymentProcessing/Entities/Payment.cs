using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessing.Entities
{
    [Table("VsPayments")]
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentDate { get; set; }
        public double PaymentAmount { get; set; }

        public string PaymentMode { get; set; }

        public string PaymentStatus { get; set; }
        public string TransactionId { get; set; }
    }
}
