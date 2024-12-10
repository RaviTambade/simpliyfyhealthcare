using OrdersProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersProcessing.Repositories.ORM;
using OrdersProcessing.Models;

namespace OrdersProcessing.Services.ORM
{
    public class OrderService : IOrderService
    {
        public bool Delete(int id)
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.Delete(id);
        }

        public List<Order> GetAll()
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.GetAll();
        }

        public List<Order> GetCustomerOrders(int id)
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.GetCustomerOrder(id);
        }

        public Order GetOrder(int id)
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.GetOrder(id);
        }

        public bool Insert(Order order)
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.Insert(order);
        }

        public bool Update(Order order)
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.Update(order);
        }
        public OrderResponse GetOrderDetails(int id)
        {
            IOrderRepository _repo = new OrderRepository();
            return _repo.GetOrderDetails(id);
        }
    }
}
