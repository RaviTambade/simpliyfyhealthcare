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

        
    }

}
