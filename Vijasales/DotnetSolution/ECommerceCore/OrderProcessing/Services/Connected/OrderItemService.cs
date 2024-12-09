using OrderProcessing.Repositories.Connected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcessing.Entities;
using ShoppingCart.Entities;

namespace OrderProcessing.Services.Connected
{
    public class OrderItemService : IOrderItemService
    {

        private IOrderItemRepository _svc;
        public OrderItemService(IOrderItemRepository svc)
        {
            this._svc = svc;
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
