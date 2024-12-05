using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    internal class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
                Task<Person> obTask = Task.Run(() => { 
                    Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);                  
                    Person thePerson = new Person
                    {
                        FirstName = "Sarika",
                        LastName = "Jadhav"
                    };
                    return thePerson; 
                });
                Console.WriteLine(obTask.Result.FirstName + obTask.Result.LastName);

            }
    }
}
