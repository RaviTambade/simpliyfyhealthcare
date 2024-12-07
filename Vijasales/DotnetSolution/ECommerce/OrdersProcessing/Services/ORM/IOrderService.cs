using OrdersProcessing.Entities;
using OrdersProcessing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersProcessing.Services.ORM
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetOrder(int id);
        List<Order> GetCustomerOrders(int id);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
        OrderResponse GetOrderDetails(int id);
    }
}
