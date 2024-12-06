using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersProcessing.Entities;


namespace OrdersProcessing.Services
{
    public interface IOrderservice
    {
        List<Order> GetAll();
        Order GetOrder(int id);
        List<Order> GetCustomerOrders(int id);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
