using ShipmentLib.Entities;
using ShipmentLib.Repositories;
using ShipmentLib.Repositories.ORM;


Console.WriteLine("TESTING SHIPMENT!");


IShipmentRepository repo = new ShipmentRepository();


foreach (Shipment sh in repo.GetByStatus("Order Confirmed"))
{
    Console.WriteLine($"{sh.Id} {sh.ShipmentDate}, status - {sh.ShipmentStatus}");
}


Console.WriteLine("Giving One Shipment");

Shipment theshipment = repo.GetById(4);
Console.WriteLine($"{theshipment.Id} {theshipment.ShipmentDate}");

