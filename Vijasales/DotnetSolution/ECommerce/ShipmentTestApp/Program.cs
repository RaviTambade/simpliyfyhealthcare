using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipment.Entities;
using Shipment.Repositories;
using Shipment.Repositories.ORM;
using Shipment.Services;
using System.Data.Entity;

namespace ShipmentTestApp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            IShipmentRepository repo= new ShipmentRepository();
            IShipmentService svc= new ShipmentService();
            List<Delivery> deliveryList = svc.GetAllAsync().GetAwaiter().GetResult();

            foreach (Delivery delivery in deliveryList)
            {
                Console.WriteLine(delivery);
            }
            Console.ReadLine();


        }
    }
}
