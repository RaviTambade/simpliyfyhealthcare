
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;
namespace Specification
{
    public class CartService : ICartService
    {

        public bool AddToCart(Item item)
        {
            return false;
           
        }

        public bool Empty()
        {
            return false;   
            
        }

        public List<Item> GetAll()
        {
           return new List<Item>();
        }

       
        public bool RemoveFromCart(int id)
        {
            throw new NotImplementedException();
        }
    }
}
