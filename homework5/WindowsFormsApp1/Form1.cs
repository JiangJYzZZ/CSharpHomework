using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawTree(9, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 30 * Math.PI / 180;
        double per1 = 0.7;
        double per2 = 0.5;

        void drawTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(n,x0, y0, x1, y1);

            drawTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawTree(n - 1, x1, y1, per2 * leng, th - th2);
            drawTree(n - 1, x1, y1, per2 * leng, th + 1);

        }

        void drawLine(int q,double x0,double y0,double x1,double y1)
        {
            if(q/2 == 0)
                graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
            else if (q / 5 == 0)
                graphics.DrawLine(Pens.Brown, (int)x0, (int)y0, (int)x1, (int)y1);
            else
                graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);

        }
    }
}
