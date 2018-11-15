using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Xsl;
namespace homework7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            OrderSev.newOrder("Jane", "water", "20180909111", "2", 13828392213);
            OrderSev.newOrder("Jack", "phone", "1111", "4332",16628393326);
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

        private void button3_Click_1(object sender, EventArgs e)          //检验
        {
            foreach (OrderDet a in OrderSev.myOrd)
            {
                long bb = Convert.ToInt64(a.nub);
                if (a.phone >= 99999999999 || a.phone <= 10000000000)         //检验手机号
                {
                    label2.Text = "Wrong Order!";
                }
                else if (bb >= 99999999999 || bb <= 10000000000)
                {
                    label2.Text = "Wrong Order!";
                }
                else
                    label2.Text = "Right!";
            }
        }

        private void GetHtmlByXml(string xmlPath, string xslPath)
        {

            XslCompiledTransform trans = new XslCompiledTransform();
            trans.Load(xslPath);
            trans.Transform(xmlPath, "hahha.html");

        }
        private void button5_Click(object sender, EventArgs e)
        {          
                string filePath = "my.xml";

                OrderSev.Export( filePath);
                GetHtmlByXml(filePath, ".../.../my.xsl");
           
         
        }
    }
}
