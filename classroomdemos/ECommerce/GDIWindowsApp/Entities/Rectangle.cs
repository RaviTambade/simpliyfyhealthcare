using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GDIWindowsApp.Entities.Drawing
{

    [Serializable]
    public class Rectangle : Shape
    {
      
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }

        public Rectangle() { }
        public Rectangle(Point startPoint, Point endPoint, Color c, int thickness)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Thickness = thickness;
            this.Color = c;
        }
        public override void Draw(Graphics g)
        {
            Pen thePen = new Pen(this.Color, this.Thickness);
            float width = EndPoint.X - StartPoint.X;
            float height = EndPoint.Y - StartPoint.Y;
            g.DrawRectangle(thePen, StartPoint.X, StartPoint.Y, width, height);


        }
    }
}