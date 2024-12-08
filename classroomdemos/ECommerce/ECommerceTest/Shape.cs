using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTest
{
    //we can not create object from abstract class
    //abstract classes are used to define abstract methods
    //minimum one method has to be abstract
    public abstract class Shape
    {
        public string Color {  get; set; }
        public int Thickness {  get; set; }

        //Abstract method do not have implementation
        public abstract void Draw();
    }
}
