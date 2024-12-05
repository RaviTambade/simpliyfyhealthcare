using OrderProcessing.Entities;
namespace OrderProcessing.Services.Connected
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetOrder(int id);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id );

        List<Order> GetCustomerOrders(int id);

    }
}
