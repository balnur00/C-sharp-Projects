using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPaint
{
    enum Tools
    {
        Pen,
        Brush,
        Fill,
        Rectangle,
        Triangle,
        Circle,
        Star,
        Line
    }
    enum BmpCreationMode
    {
        AfterFill,
        FromFile,
        Init
    }
    public partial class Form1 : Form
    {
        Graphics gfx = default(Graphics);
        Bitmap bmp = default(Bitmap);
        Point firstPoint = default(Point);
        Point secondPoint = default(Point);
        Pen pen = new Pen(Color.Black, 1);
        Tools activeTool = MyPaint.Tools.Pen;

        public Form1()
        {
            InitializeComponent();
            SetupCanvas(BmpCreationMode.Init, "");

            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void SetupCanvas(BmpCreationMode mode, string fileName)
        {
            if( mode ==BmpCreationMode.Init)
            {
                bmp = new Bitmap(Canvas.Width, Canvas.Height);
            }
            else if(mode == BmpCreationMode.FromFile)
            {
                bmp = new Bitmap(Bitmap.FromFile(openFileDialog1.FileName));
            }else if(mode == BmpCreationMode.AfterFill)
            {

            }

            gfx = Graphics.FromImage(bmp);
            if (mode== BmpCreationMode.Init)
            {
                gfx.Clear(Color.White);
            }
            Canvas.Image = bmp;
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if (activeTool == MyPaint.Tools.Fill)
            {
                MapFill mf = new MapFill();
                mf.Fill(gfx, firstPoint, pen.Color, ref bmp);
                SetupCanvas(BmpCreationMode.AfterFill, "");
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            switch (activeTool)
            {
                case MyPaint.Tools.Pen:
                    break;
                case MyPaint.Tools.Brush:
                    break;
                case MyPaint.Tools.Fill:
                    break;
                case MyPaint.Tools.Rectangle:
                    gfx.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case MyPaint.Tools.Triangle:
                    secondPoint = e.Location;
                    Rectangle rectangle = new Rectangle(Math.Min(secondPoint.X, firstPoint.X), Math.Min(secondPoint.Y, firstPoint.Y), Math.Abs(secondPoint.X - firstPoint.X), Math.Abs(secondPoint.Y - firstPoint.Y));

                    Point a = new Point(rectangle.X + rectangle.Width / 2, rectangle.Y);
                    Point b = new Point(rectangle.X, rectangle.Y + rectangle.Height);
                    Point c = new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);

                    Point[] points = {
                            a,
                            b,
                            c
                           };
                    gfx.DrawPolygon(pen, points);
                    break;
                case MyPaint.Tools.Circle:
                    gfx.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case MyPaint.Tools.Star:
                    break;
                case MyPaint.Tools.Line:
                    gfx.DrawLine(pen, firstPoint, secondPoint);
                    break;
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;
                switch (activeTool)
                {
                    case MyPaint.Tools.Pen:
                        gfx.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case MyPaint.Tools.Brush:
                        break;
                    case MyPaint.Tools.Fill:
                        break;
                    case MyPaint.Tools.Rectangle:
                        break;
                    case MyPaint.Tools.Triangle:
                        
                        break;
                    case MyPaint.Tools.Circle:
                        break;
                    case MyPaint.Tools.Star:
                        break;
                    case MyPaint.Tools.Line:
                        break;
                }
                Canvas.Refresh();
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetupCanvas(BmpCreationMode.FromFile, openFileDialog1.FileName);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Canvas.Image.Save(saveFileDialog1.FileName);
            }
        }


        private void penToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Pen;
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Fill;
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Rectangle;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Circle;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Triangle;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Line;
        }

        private void starToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Star;
        }

        private void brushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeTool = MyPaint.Tools.Brush;
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle rec = new Rectangle(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));
            return rec;
        }

        //public class Triangle
        //{

        //    public void GetRightTriangle(Point p1, Point p2)
        //    {
        //        Point p3;

        //        p3.X = p1.X;
        //        p3.Y = p2.Y;
        //    }
        //}

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            switch (activeTool)
            {
                case MyPaint.Tools.Pen:
                    break;
                case MyPaint.Tools.Brush:
                    break;
                case MyPaint.Tools.Fill:
                    break;
                case MyPaint.Tools.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case MyPaint.Tools.Triangle:
                    Rectangle rectangle = new Rectangle(Math.Min(secondPoint.X, firstPoint.X), Math.Min(secondPoint.Y, firstPoint.Y), Math.Abs(secondPoint.X - firstPoint.X), Math.Abs(secondPoint.Y - firstPoint.Y));

                    Point a = new Point(rectangle.X + rectangle.Width / 2, rectangle.Y);
                    Point b = new Point(rectangle.X, rectangle.Y + rectangle.Height);
                    Point c = new Point(rectangle.X + rectangle.Width, rectangle.Y + rectangle.Height);

                    Point[] points = {
                            a,
                            b,
                            c
                           };
                    e.Graphics.DrawPolygon(pen, points);

                    break;
                case MyPaint.Tools.Circle:
                    e.Graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case MyPaint.Tools.Star:
                    break;
                case MyPaint.Tools.Line:
                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Color.Aquamarine;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void oneMM_Click(object sender, EventArgs e)
        {
            pen.Width = 1.0F;
        }

        private void twoMM_Click(object sender, EventArgs e)
        {
            pen.Width = 2.0F;
        }

        private void threeMM_Click(object sender, EventArgs e)
        {
            pen.Width = 3.0F;
        }

        private void fourMM_Click(object sender, EventArgs e)
        {
            pen.Width = 4.0F;
        }

        private void fiveMM_Click(object sender, EventArgs e)
        {
            pen.Width = 5.0F;
        }
    }
}