using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Repositories.Connected
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetOrder(int id);
<<<<<<< HEAD
=======
        List<Order> GetCustomerOrder(int customerId);
>>>>>>> b0c17e237b863f7216a7b86c16fa089738de0f31
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
