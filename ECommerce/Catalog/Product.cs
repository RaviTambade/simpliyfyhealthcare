using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    //Business entity class which contains only data
    //are called POCO classes in .net 
    //POCO: Plain Old CLR Objects

    public class Product
    {
        public int Id { get; set; }  //auto property
        public string Name { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}
