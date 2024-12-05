using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceDALLib.DisConnectedDataAccess;
using ECommerceEntities;
namespace DisConnectedTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = DBManager.GetAll();

            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }


        }
    }
}
