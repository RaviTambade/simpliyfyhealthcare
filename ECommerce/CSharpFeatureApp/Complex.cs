using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatureApp
{
    public class Complex
    {

        //private data members

        private int real;
        private int imag;

        //constructor overloading
        public Complex() { 
        this.real=this.imag=0;
        }
        public Complex(int real, int imag)
        {
            this.real = real;
            this.imag = imag;
        }

        //Method overriding
        public override string ToString()
        {
            return  this.real+ "+ i"+this.imag;
        }
     


        //Operator overloading
        // + , -, *, /  (Arithmatic operators)
         public static Complex  operator+ (Complex a, Complex b) {
            Complex temp = new Complex();
            temp.real=a.real+b.real;
            temp.imag=a.imag+b.imag;
            return temp;
        }

        public static Complex operator -(Complex a, Complex b)
        {
            Complex temp = new Complex();
            temp.real = a.real - b.real;
            temp.imag = a.imag - b.imag;
            return temp;
        }


        public static Complex operator*(Complex a, Complex b)
        {
            Complex temp = new Complex();
            temp.real = a.real *b.real;
            temp.imag = a.imag * b.imag;
            return temp;
        }
        public static Complex operator /(Complex a, Complex b)
        {
            Complex temp = new Complex();
            temp.real = a.real/ b.real;
            temp.imag = a.imag / b.imag;
            return temp;
        }

    }
}
