namespace ShipmentLib.Entities
{
    public class Shipment
    {
      
            public int Id { get; set; }
            public DateTime ShipmentDate { get; set; }
            public int OrderId { get; set; }
            public string ShipmentStatus { get; set; } = "Order Confirmed";
           

         
    }
}
