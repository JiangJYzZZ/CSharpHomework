using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OrderSev.newOrder("Jane", "water", "1102", "2");
            OrderSev.newOrder("Jack", "phone", "1111", "4332");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)             //删除
        {
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)               //新建
        {           
            form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text;
            OrderDet b = OrderSev.findOrderNub(a);
            textBox2.Text = b.name;
            textBox3.Text = b.nub;
            textBox4.Text = b.price;
            textBox5.Text = b.product;

        }
    }
}
