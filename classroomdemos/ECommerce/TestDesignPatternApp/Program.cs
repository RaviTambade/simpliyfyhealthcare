using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDesignPatternApp
{

    public class Complex:ICloneable
    {
        public int real;
        public int imag;
        public Complex()
        {
            real=imag=0;
        }
        public Complex(int r, int i)
        {
            this.real = r;
            this.imag =i;
        }

        public object Clone()
        {
            Complex temp = new Complex();
            temp.real = this.real;
            temp.imag = this.imag;
            return temp;    
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Complex c=new Complex(1, 2);
            Complex c2 = (Complex)c.Clone();

            Console.WriteLine(c.real + " , " + c.imag);
            Console.WriteLine(c2.real+ " , "+c2.imag);

          

        }
    }
}


/*

  OfficeBoy waiter =  OfficeBoy.Create();
  OfficeBoy admin = OfficeBoy.Create();
  OfficeBoy supervisor= OfficeBoy.Create();
 */