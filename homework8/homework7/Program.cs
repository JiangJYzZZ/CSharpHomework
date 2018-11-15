using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Xsl;


namespace homework7
{
  
    public class Oreder
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }

    public class OrderDet
    {
        public string name;            //客户名，产品名,订单号  
        public string product;
        public string nub;
        public string price;
        public long  phone;

        public OrderDet(string name, string num, string pro, string pri,long ph)
        {
            this.name = name;
            this.nub = num;
            this.product = pro;
            this.price = pri;
            this.phone = ph;
        }

    }

    public class OrderSev
    {
        public  static List<OrderDet> myOrd = new List<OrderDet>();     


        //添加
        public static bool newOrder(string yname, string yproduct, string ynub, string ypri,long yph)  //传入新商品信息
        {
        foreach(OrderDet x in myOrd)
            {
                if(ynub.Equals(x.nub))
                {
                    Console.WriteLine("订单存在！");
                    return false;
                }
            }

            myOrd.Add(new OrderDet(yname, ynub, yproduct, ypri,yph));
                return true;
            
        }


        //删除
        public static bool deOrder(string a)  //按订单号删除
        {

            try
            {
             foreach (OrderDet x in myOrd)
                {
                    if (a.Equals(x.nub))
                    {
                        myOrd.Remove(x);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        public static OrderDet findOrderNub(string n)     //按订单号查找
        {
            try
            {
                foreach (OrderDet x in myOrd)
                {
                    if (n.Equals(x.nub))
                    {
                        Console.WriteLine("Find!");
                        return x;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public OrderDet findOrderName(string n)     //按名字查找
        {
            try
            {
                foreach (OrderDet x in myOrd)
                {
                    if (n.Equals(x.name))
                    {
                        return x;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        //修改
        public static bool changeOrder( string name1, string product1, string nub1, string pri1,string aa,long bb)    
        {
            foreach (OrderDet a in myOrd)
            {
                a.name = name1;
                a.nub = nub1;
                a.product = product1;
                a.nub = nub1;
                a.phone = bb;
                return true;
            }
            return false;
        }


        //使用Linq查询

        public void findOrderLinqName(string n)     //传入客户名
        {
            var m = from x in myOrd
                    where x.name.Equals(n)
                    select x;
            foreach (var q in m)
            {
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product + "  price:" + q.price +" phone:" + q.phone);
            }
        }

        //查询大于10000的订单
        public void findOrderLinqPri(string n)
        {
            var m = from x in myOrd
                    where Convert.ToInt32(x.price) >= Convert.ToInt32(n)
                    select x;
            foreach (var q in m)
            {
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product + "  price:" + q.price + " phone:" + q.phone);
            }
        }


        //XML
        public static void XmlSerializer(XmlSerializer ser, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, OrderSev.myOrd);
            fs.Close();
        }
        public static void Export(string filePath)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderDet));
            XmlSerializer(xmlser, filePath);
        }

        public static string Import(string xmlFileName)
        {
            string xml = File.ReadAllText(xmlFileName);
            return xml;
        }


    }
}
