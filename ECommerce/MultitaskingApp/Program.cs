using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;

namespace MultitaskingApp
{
    internal class Program
    {
        public static void Process1()
        {
            int count = 45;
            while (true)
            {
                Console.WriteLine("Process1 function caller :" + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("doing something important");
                Thread.Sleep(1000);
            }
        }

        public static void Process2()
        {
            int count = 45;
             while (true)
            {
                Console.WriteLine("doing something important");
                Console.WriteLine("Process2  function caller :" + Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            Thread thread2= new Thread(Process1);
            Thread thread3 = new Thread(Process2);
            thread2.Start();
            thread3.Start();

    
            while (true)
            {
                Console.WriteLine("Hello World !");
                Thread.Sleep(1000);
                Console.WriteLine("Main function caller :" + Thread.CurrentThread.ManagedThreadId);
            }

        }
    }
}
