using ShipmentLib.Entities;
using ShipmentLib.Repositories;
using ShipmentLib.Repositories.ORM;


Console.WriteLine("TESTING SHIPMENT!");


IShipmentRepository repo = new ShipmentRepository();


foreach( Shipment sh in repo.GetAll())
{
    Console.WriteLine($"{sh.Id} {sh.ShipmentDate}, status - {sh.ShipmentStatus}" );
}