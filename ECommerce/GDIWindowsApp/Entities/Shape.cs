using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDIWindowsApp.Entities.Drawing
{
    [Serializable]
    public abstract class Shape
    {
        public Color Color { get; set; }
        public int Thickness {  get; set; }
        public abstract void Draw(Graphics g);
    }
}
