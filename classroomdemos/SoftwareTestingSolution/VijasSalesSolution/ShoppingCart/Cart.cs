using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public class Cart
    {
        private List<Item> items;

        public Cart() {
            items = new List<Item>();
        }
        public bool AddToCart(Item item)
        {
            if (items == null) { return false;}
            items.Add(item);
            return true;
        }

        public bool RemoveFromCart(Item item) { 
            return items.Remove(item);
        }
        public bool Contains(Item item) {  
            return items.Contains(item);
        }

        public void Clear() {  items.Clear(); }
        public List<Item> GetItems() { return items;}
    }
}
