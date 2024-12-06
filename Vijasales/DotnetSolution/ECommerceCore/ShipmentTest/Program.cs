using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Repositories.ORM;


Console.WriteLine("TESTING SHIPMENT!");


IShipmentRepository repo = new ShipmentRepository();


foreach (Delivery sh in repo.GetByStatus("Order Confirmed"))
{
    Console.WriteLine($"{sh.Id} {sh.ShipmentDate} {sh.Status}");
}


Console.WriteLine("Giving One Shipment");

Delivery theshipment = repo.GetById(4);
Console.WriteLine($"{theshipment.Id} {theshipment.ShipmentDate}");

