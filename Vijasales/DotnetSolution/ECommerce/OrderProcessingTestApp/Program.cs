using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersProcessing.Services;
using OrdersProcessing.Entities;

namespace OrderProcessingTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IOrderservice svc =new OrderService();
            List<Order> orders =svc.GetAll();
            foreach(Order o in orders)
            {
                Console.WriteLine(o);
            }

            Console.ReadLine();

        }
    }
}
