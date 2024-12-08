using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderProcessing.Entities;
using ShoppingCart.Entities;

namespace OrderProcessing.Services.Connected
{
    public interface IOrderItemService
    {
        Task<bool> InsertOrderItemAsync(Cart cart);
        Task<bool> UpdateOrderItemAsync(int customerId, OrderItem item);
        Task<bool> DeleteOrderItemAsync(int orderId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetAllOrderItemsAsync(int orderId);
        Task<List<OrderItem>> GetAllOrderItemsByCustomerIdAsync(int orderId);
    }
}
