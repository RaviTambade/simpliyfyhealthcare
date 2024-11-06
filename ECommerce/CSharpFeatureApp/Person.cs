using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatureApp
{
    public class Person
    {
        //encapsulation
        private  string fname;
        private string lname;
        private  int age;

        public Person() {
            this.fname = "Ravi";
            this.lname = "Tambade";
            this.age = 49;
        }
        public Person(string fname, string lname, int age)
        {
            // this: self reference
            this.fname = fname;
            this.lname = lname;
            this.age = age;
        }
        public override string ToString()
        {
             return this.fname + " " + this.lname + " " + this.age;
        }

        public  void ShowDetails()
        {
            Console.WriteLine(this.fname + " " + this.lname);
        }

    }
}
