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
        List<Order> GetCustomerOrder(int customerId);
=======
<<<<<<< HEAD
=======
        List<Order> GetCustomerOrder(int customerId);
>>>>>>> b0c17e237b863f7216a7b86c16fa089738de0f31
>>>>>>> 4614edbc238c9721cc014ff9098f27cee55beed8
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
