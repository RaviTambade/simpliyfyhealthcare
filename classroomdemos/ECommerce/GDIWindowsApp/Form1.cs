using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIWindowsApp.Entities.Drawing;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Rectangle = GDIWindowsApp.Entities.Drawing.Rectangle;

namespace GDIWindowsApp
{
    public partial class Form1 : Form
    {

        public Point point2;
        public Point point1;
        public int shapeFlag = 1;
        public Color penColor;
        public int thickness = 1;

        List<Shape> shapes = new List<Shape>();


        public Form1()
        {
            InitializeComponent();
        }

        private void OnFileOpen(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
 
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                string fileName = ofd.FileName;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(fileName, FileMode.Open);
                shapes=(List<Shape>)bf.Deserialize(fs);
                fs.Close();
            }
        }

        private void OnFileExit(object sender, EventArgs e)
        {

            this.Close();

        }

        private void OnFileSaveAs(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                string fileName=ofd.FileName;
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate);
                bf.Serialize(fs, shapes);
                fs.Close();
                
            }

        }

        private void OnFormLoad(object sender, EventArgs e)
        {

        }

        private void OnFormMouseDown(object sender, MouseEventArgs e)
        {
          //  MessageBox.Show("Down event");
         point1=new Point(e.X,e.Y);
        }

        private void OnFormMouseMove(object sender, MouseEventArgs e)
        {

        }

        private void OnFormMouseUp(object sender, MouseEventArgs e)
        {
            // MessageBox.Show("Up event");
            point2 = new Point(e.X, e.Y);
            //DI
            //constructor dependency injection
            //method dependency injection
            //propetyr dependency injection

            //consturctor dependency injection example
            
            Graphics g=this.CreateGraphics();
            Shape shape = null;
            switch (shapeFlag)
            {
                case 1:

                    {
                        shape = new Line(point1,point2, penColor,thickness);
                        shape.Draw(g);
                    }
                   
                    break;
                case 2:
                    {
                        shape = new Rectangle(point1, point2, penColor, thickness);
                        shape.Draw(g);
                    }
                    break;
            }

            shapes.Add(shape);
            this.Invalidate();
            //method dependency injection example

        }

        private void OnShapeLine(object sender, EventArgs e)
        {
            this.shapeFlag = 1;

        }

        private void OnShapeRectangle(object sender, EventArgs e)
        {

            this.shapeFlag = 2;
        }

        private void OnShapeColor(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.penColor = dlg.Color;
            }
        }

        private void OnShapeThickness1(object sender, EventArgs e)
        {
            thickness = 1;

        }

        private void OnShapeThickness2(object sender, EventArgs e)
        {
            thickness = 2;
        }

        private void OnShapeThickness4(object sender, EventArgs e)
        {
            thickness = 4;

        }

        private void OnFormPaint(object sender, PaintEventArgs e)
        {

            foreach (var shape in shapes)
            {
                shape.Draw(e.Graphics);
            }
        }
    }
}
