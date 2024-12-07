using OrderProcessing.Entities;
using OrderProcessing.Repositories.Connected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Service
{
    public class OrderService : IOrderService
    {
          
        IOrderRepository _svc;
        public OrderService() 
        {
            _svc=new OrderRepository();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetCustomerOrders(int id)
        {
            return _svc.GetCustomerOrder(id);
        }


        public List<Order> GetAll()
        {
            return _svc.GetAll();
        }



        public Order GetOrder(int id)
        {
            return _svc.GetOrder(id);
        }

        public bool Insert(Order order)
        {
            return _svc.Insert(order);
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }

    }
}
