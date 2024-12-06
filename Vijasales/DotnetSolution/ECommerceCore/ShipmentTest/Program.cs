using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Repositories.ORM;


Console.WriteLine("TESTING SHIPMENT!");


IShipmentRepository repo = new ShipmentRepository();


DateTime dateTime = new DateTime(2024, 12, 14);

foreach (Delivery sh in repo.GetByDate(dateTime))
{
    Console.WriteLine(sh);
}


Console.WriteLine("Giving One Shipment");

Delivery theshipment = repo.GetById(4);
Console.WriteLine(theshipment);

