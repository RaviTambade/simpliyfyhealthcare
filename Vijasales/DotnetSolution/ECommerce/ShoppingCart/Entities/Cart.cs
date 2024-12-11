using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Entities
{
    [Serializable]
    public class Cart
    {
        public List<Items> Items { get; set; }
        public Cart()
        {
            Items = new List<Items>();
        }

    }
}
