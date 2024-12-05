using OrderProcessing.Entities;
namespace OrderProcessing.Services.Connected
{
    public interface IOrderService
    {
        List<Order> GetAll();
        Order GetOrder(int id);
        List<Order> GetCustomerOrders(int id);
        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id );

<<<<<<< HEAD

=======
        List<Order> GetCustomerOrders(int id);
>>>>>>> b0c17e237b863f7216a7b86c16fa089738de0f31

    }
}
