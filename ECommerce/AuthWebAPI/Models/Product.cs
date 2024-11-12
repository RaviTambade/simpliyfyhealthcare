using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthWebAPI.Models
{
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