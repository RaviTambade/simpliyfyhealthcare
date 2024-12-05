using OrderProcessing.Entities;
using OrderProcessing.Repositories.Connected;

namespace OrderProcessing.Services.Connected
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _svc;
        public OrderService(IOrderRepository svc) { 
            this._svc = svc;
        }
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return _svc.GetAll();
        }

        public List<Order> GetCustomerOrders(int id)
        {
            return _svc.GetCustomerOrder(id);
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
