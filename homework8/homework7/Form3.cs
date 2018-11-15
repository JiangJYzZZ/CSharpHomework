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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            string pri1 = textBox4.Text;
            string nub = textBox2.Text;
            string prod = textBox1.Text;
            long yph = Convert.ToInt64(textBox5.Text);
            OrderSev.newOrder(name,prod,nub,pri1,yph);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
