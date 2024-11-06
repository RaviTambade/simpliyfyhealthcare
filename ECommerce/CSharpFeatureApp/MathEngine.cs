using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatureApp
{
    public  class MathEngine
    {
        //member varibale ( instance variable)
        public  static readonly  double PI;
        public const int num=98;

        static  MathEngine()
        {
            PI = 3.14;
        }

        //function overloading (method overloading)
        public  int Add(int op1, int op2)
        {
            return op1 + op2;
        }
        public int Add(int op1, int op2, int op3)
        {
            return op1 + op2 + op3;
        }

        public static void ViewNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }


        //helper function
        public static void ShowDetails(object o)
        {
            Console.WriteLine(o);  
            //it automatically calls ToString() of dervied class
        }
    }
}
