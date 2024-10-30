using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTest
{
    public class Circle : Shape
    {
        public int Radius { get; set; }
        public Point Center {  get; set; }   
        public override void Draw()
        {
            const double PI = 3.14;
            double area=PI * Radius*Radius;
            Console.WriteLine(" Area of Circle" + area);
            
        }
    }
}
