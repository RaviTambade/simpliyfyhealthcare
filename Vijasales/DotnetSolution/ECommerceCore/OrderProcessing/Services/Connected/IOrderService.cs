using OrderProcessing.Entities;
using ShoppingCart.Entities;
namespace OrderProcessing.Services.Connected
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();           
        Task<Order> GetOrderAsync(int id);         
        Task<List<Order>> GetCustomerOrdersAsync(int id);  
        Task<bool> InsertAsync(Order order);       
        Task<bool> UpdateAsync(Order order);       
        Task<bool> DeleteAsync(int id);
        Task<List<OrderList>> GetOrderDetailsAsync(int customerId);

        Task<bool> InsertOrderItemAsync(Cart cart);
        Task<bool> UpdateOrderItemAsync(int customerId, OrderItem item);
        Task<bool> DeleteOrderItemAsync(int orderId);
        Task<OrderItem> GetOrderItemByIdAsync(int orderItemId);
        Task<List<OrderItem>> GetAllOrderItemsAsync(int orderId);
        Task<List<OrderItem>> GetAllOrderItemsByCustomerIdAsync(int orderId);
    }

}
