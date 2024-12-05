using System;

using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using CRM;

//namespace is a logical collection of classes
//namespace can contain child namespaces as well

namespace ECommerceTest
{

    //There are access specifiers in .net C#
    //public:this can be accessed from external code
    //private:these methods or memebers could be accessed only
    //        throuhg public methods
    //protected:these methods or members could be accessed through
    //          child classes
    //internal: this is also called as assembly scope
    //          type defiend using internal could be accessed
    //          only in dll , it contains


    internal class Program
    {
        static void Main(string[] args)
        {
            //primitive data types

            int count = 56;
            
            double amount = 7890.8;
            char ch = 'Y';

            Student student = new Student();


            Customer customer1 = new Customer();
            customer1.Id = 34;
            customer1.FirstName = "Rajan";
            customer1.LastName = "Patil";
            customer1.Email = "rajan.patil@gmail.com";
            customer1.Contact = "9881735801";

            Customer customer2 = new Customer();
            customer2.Id = 38;
            customer2.FirstName = "Seema";
            customer2.LastName = "Nene";
            customer2.Email = "seema.nene@gmail.com";
            customer2.Contact = "9881735802";


            ICustomerService customerService = new CustomerService();
            customerService.Insert(customer1);
            customerService.Insert(customer2);

            List<Customer> allCustomers= customerService.GetAll();
            foreach (Customer customer in allCustomers) { 
                Console.WriteLine(customer.FirstName);
                Console.WriteLine(customer.LastName);
                Console.WriteLine(customer.Email);
                Console.WriteLine(customer.Contact);
            }


            Shape shape = new Line();

            int[] marks = { 45, 76, 87, 56 };
            int num = marks[3];

            List<int> numbers = new List<int>();
            numbers.Add(67);
            numbers.Add(5600);

            foreach (int number in numbers)
            {
                int theValue = number;
            }
           

             
            //Boxing:
            //converting value type varaible into refernce type varaible
            //UnBoxing:
            //converting refernce type variable into value type variable



           Queue<string> queue= new Queue<string>();
            queue.Enqueue("tambade");
            queue.Enqueue("Nene");
            string surname=queue.Dequeue();

            Dictionary<string,Customer> contacts= new Dictionary<string,Customer>();
            contacts.Add("manager", customer2);
            contacts.Add("director", customer1);


            Customer c = contacts["manager"];

            Console.ReadLine();
        }
    }
}
