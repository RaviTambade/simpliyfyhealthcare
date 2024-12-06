namespace Shipment.Entities
{
    public class Delivery
    {
      
            public int Id { get; set; }
            public DateTime ShipmentDate { get; set; }
            public int OrderId { get; set; }
            public string Status { get; set; } = "Pending";

        public override string ToString()
        {
            return Id + " "+OrderId + " "+Status;
        }


    }
}
