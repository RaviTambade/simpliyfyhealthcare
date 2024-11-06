using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HR
{
    //concrete class : we can create object from class
    public class Employee
    {
        //Auto property
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicSalary {  get; set; }
        public double HRA {  get; set; }
        public double DA { get; set; } 


        //virual method always have implementation
        public virtual double ComputePay()
        {
            return BasicSalary + HRA + (25 * DA);
        }
    }

    //in java  it is called as Final class
    public  sealed  class Manager:Employee
    {
        public double Incentive {  get; set; }
        public  override  double ComputePay()
        {
            return Incentive + base.ComputePay();
        }
    }
}
