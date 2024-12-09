using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Repositories.Connected
{
    public interface IOrderItemRepository
    {
        Task<bool> InsertOrderItemAsync(OrderItem item);
        Task<bool> UpdateOrderItemAsync(int customerId, OrderItem item);
        Task<bool> DeleteOrderItemAsync(int orderId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetAllOrderItemsAsync(int orderId);
        Task<List<OrderItem>> GetAllOrderItemsByCustomerIdAsync(int orderId);
    }
}
