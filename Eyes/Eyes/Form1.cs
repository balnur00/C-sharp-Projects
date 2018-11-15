using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eyes
{
    public partial class Form1 : Form
    {
        int x, y;
        Point p1 = default(Point);
        Point p2 = default(Point);
        Graphics gfx = default(Graphics);
        Pen pen = new Pen(Color.Yellow);

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        Graphics gfx;
        
        
        public Form1()
        {
            InitializeComponent();
            gfx = Graphics.FromHwnd(this.Handle);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        }

        
    }
}
