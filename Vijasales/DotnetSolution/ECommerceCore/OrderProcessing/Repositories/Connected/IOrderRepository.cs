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
        Task<List<OrderList>> GetCustomerOrderAsync(int customerId);  
        Task<int> InsertAsync(Order order);       
        Task<bool> UpdateAsync(Order order);      
        Task<bool> DeleteAsync(int id);
        Task<List<OrderList>> GetOrderDetailsAsync(int customerId);

        
    }

}
