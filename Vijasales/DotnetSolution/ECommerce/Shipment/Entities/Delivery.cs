using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipment.Entities
{
    [Table("VsShipments")]
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; } = "Pending";

        public override string ToString()
        {
            return Id + " " + OrderId + " " + Status;
        }


    }
}
