using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceEntities;

namespace Specification
{
   public interface ICartService
    {
        List<Item> GetAll();
        bool AddToCart(Item item);
        bool RemoveFromCart(int id);
        bool Empty();
    }
}
