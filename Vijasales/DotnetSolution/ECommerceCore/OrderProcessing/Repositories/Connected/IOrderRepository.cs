using OrderProcessing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessing.Repositories.Connected
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();           
        Task<Order> GetOrderAsync(int id);         
        Task<List<Order>> GetCustomerOrderAsync(int customerId);  
        Task<bool> InsertAsync(Order order);       
        Task<bool> UpdateAsync(Order order);      
        Task<bool> DeleteAsync(int id);
        Task<List<OrderList>> GetOrderDetailsAsync(int customerId);

        Task<bool> InsertOrderItemAsync(OrderItem item);
        Task<bool> UpdateOrderItemAsync(int customerId, OrderItem item);
        Task<bool> DeleteOrderItemAsync(int orderId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetAllOrderItemsAsync(int orderId);
        Task<List<OrderItem>> GetAllOrderItemsByCustomerIdAsync(int orderId);
    }

}
