// See https://aka.ms/new-console-template for more information


//using OrderProcessing.Entities;
//using OrderProcessing.Repositories.Connected;

//OrderRepository _repo = new OrderRepository();
//List<Order> orders = await _repo.GetAllAsync();
public class Program
{
    // Uncomment the following line to resolve.
    static void Main() { }
}

/*
OrderRepository _orderRepository = new OrderRepository();
Order _newOrder = new Order { CustomerId=12,Status="Shipped",OrderDate=DateTime.Now,TotalAmount=decimal.Parse("8800")};

if(_orderRepository.Insert(_newOrder)) 
        Console.WriteLine("Inserted");
List<Order> _orders = _orderRepository.GetCustomerOrder(2);

foreach(Order order in _orders)
{
    Console.WriteLine(order);
}
*/

