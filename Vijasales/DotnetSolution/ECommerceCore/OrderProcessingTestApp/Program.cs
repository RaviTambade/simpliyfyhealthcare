<<<<<<< HEAD
﻿// See https://aka.ms/new-console-template for more information


using OrderProcessing.Entities;
using OrderProcessing.Repositories.Connected;

OrderRepository _repo = new OrderRepository();
List<Order> orders = await _repo.GetAllAsync();
foreach (Order order in orders)
=======
public class Program
>>>>>>> c36ac3c3dbb36435ddc36d333dec34be8c579314
{
    // Uncomment the following line to resolve.
    static void Main() { }
}
<<<<<<< HEAD

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

=======
>>>>>>> c36ac3c3dbb36435ddc36d333dec34be8c579314
