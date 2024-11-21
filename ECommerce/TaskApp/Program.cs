using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp
{
    internal class Program
    {
            static void Main(string[] args)
            {
                Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);


            Task<string> obTask = Task.Run(() => { 
                    Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
                    return " Hello"; 
                });
                Console.WriteLine(obTask.Result);
            }
      
    }
}
