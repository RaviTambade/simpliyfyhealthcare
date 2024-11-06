using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ECommerceTest
{
    public  class Line:Shape
    {
        public Point StartPoint{get;set;}
        public Point EndPoint{get;set;}

        public override void Draw()
        {
            Console.WriteLine( StartPoint.X + " , "+  StartPoint.Y );
            Console.WriteLine(EndPoint.X + " , " + EndPoint.Y);
        }

    }
}
