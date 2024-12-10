using OrderProcessing.Entities;
using ShoppingCart.Entities;
namespace OrderProcessing.Services.Connected
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllAsync();           
        Task<Order> GetOrderAsync(int id);         
        Task<List<OrderList>> GetCustomerOrdersAsync(int id);  
        Task<int> InsertOrderAsync(int customerId, Cart cart);       
        Task<bool> UpdateOrderAsync(Order order);       
        Task<bool> DeleteAsync(int id);
        Task<List<OrderList>> GetOrderDetailsAsync(int customerId);

        
    }

}
