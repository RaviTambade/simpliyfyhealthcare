using OrderProcessing.Entities;
using OrderProcessing.Repositories.Connected;
using ShoppingCart.Entities;

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

        public async Task<List<Order>> GetCustomerOrdersAsync(int customerId)
        {
            return await _svc.GetCustomerOrderAsync(customerId);
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

        public async Task<List<OrderList>> GetOrderDetailsAsync(int customerId)
        {
            return await _svc.GetOrderDetailsAsync(customerId);
        }

        //OrdersItems
        public async Task<bool> InsertOrderItemAsync(OrderItem item)
        {
            return await _svc.InsertOrderItemAsync(item);
        }

        public async Task<bool> UpdateOrderItemAsync(int customerId, OrderItem item)
        {
            return await _svc.UpdateOrderItemAsync(customerId, item);
        }

        public async Task<bool> DeleteOrderItemAsync(int orderId)
        {
            return await _svc.DeleteOrderItemAsync(orderId);
        }

        public async Task<OrderItem> GetOrderItemByIdAsync(int orderItemId)
        {
            return await _svc.GetOrderItemByIdAsync(orderItemId);
        }

        public async Task<List<OrderItem>> GetAllOrderItemsAsync(int orderId)
        {
            return await _svc.GetAllOrderItemsAsync(orderId);
        }

        public async Task<List<OrderItem>> GetAllOrderItemsByCustomerIdAsync(int orderId)
        {
            return await _svc.GetAllOrderItemsAsync(orderId);
        }

        public Task<bool> InsertOrderItemAsync(Cart item)
        {
            throw new NotImplementedException();
        }
    }
}
