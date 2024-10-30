using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTest
{
    public abstract class Shape
    {
        public string Color {  get; set; }
        public int Thickness {  get; set; }
        public abstract void Draw();
        

    }
}
