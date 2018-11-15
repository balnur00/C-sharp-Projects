using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SolidBrush myBrush = new SolidBrush(Color.Red);
        Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.FillEllipse(myBrush, new Rectangle(0, 0, 200, 300));
        myBrush.Dispose();
        formGraphics.Dispose();
        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}
