using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcessing.Entities;

namespace OrderProcessing.Repositories.Connected
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetOrder(int id);
        List<Order> GetCustomerOrder(int customerId);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
