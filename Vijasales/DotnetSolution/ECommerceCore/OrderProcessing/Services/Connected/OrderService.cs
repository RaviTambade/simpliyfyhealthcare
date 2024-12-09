using OrderProcessing.Entities;
using OrderProcessing.Repositories.Connected;
using ShoppingCart.Entities;

namespace OrderProcessing.Services.Connected
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _svc;
        private IOrderItemService _itemService;
        public OrderService(IOrderRepository svc,IOrderItemService itemService) { 
            this._svc = svc;
            this._itemService = itemService;
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

        public async Task<bool> InsertOrderAsync(Cart cart)
        {
            Order order = new Order { CustomerId=2,Status="Pending",OrderDate=DateTime.Now };
            decimal orderTotal = 0;
            cart.Items.ForEach(item =>orderTotal+=item.Price);
            
            
            order.TotalAmount = orderTotal;
            int orderId = await _svc.InsertAsync(order);
            foreach(Items item in cart.Items)
            {
                OrderItem orderItem = new OrderItem { OrderId=orderId,Quantity=item.Quantity};
                await _itemService.InsertOrderItemAsync(orderItem);
            }
            return  true;
        }

        public async Task<bool> UpdateOrderAsync(Order order)
        {
            return await _svc.UpdateAsync(order);
        }

        public async Task<List<OrderList>> GetOrderDetailsAsync(int customerId)
        {
            return await _svc.GetOrderDetailsAsync(customerId);
        }

       
    }
}
