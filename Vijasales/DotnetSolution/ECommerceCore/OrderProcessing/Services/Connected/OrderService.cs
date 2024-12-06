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
        public async Task<bool> DeleteAsync(int id)
        {
            return await  _svc.DeleteAsync(id);
        }

        public async Task<List<Order>> GetCustomerOrdersAsync(int id)
        {
            return await _svc.GetCustomerOrderAsync(id);
        }


        public async Task<List<Order>> GetAllAsync()
        {
            return await _svc.GetAllAsync();
        }

        

        public async Task<Order> GetOrderAsync(int id)
        {
            return await _svc.GetOrderAsync(id);
        }

        public async Task<bool> InsertAsync(Order order)
        {
            return await _svc.InsertAsync(order);
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            return await _svc.UpdateAsync(order);
        }
    }
}
