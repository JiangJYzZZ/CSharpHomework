using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Text;



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

        public OrderDet(string name, string num, string pro, string pri)
        {
            this.name = name;
            this.nub = num;
            this.product = pro;
            this.price = pri;
        }

    }

    public class OrderSev
    {
        public  static List<OrderDet> myOrd = new List<OrderDet>();     


        //添加
        public static bool newOrder(string yname, string yproduct, string ynub, string ypri)  //传入新商品信息
        {
        foreach(OrderDet x in myOrd)
            {
                if(ynub.Equals(x.nub))
                {
                    Console.WriteLine("订单存在！");
                    return false;
                }
            }

            myOrd.Add(new OrderDet(yname, ynub, yproduct, ypri));
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
        public static bool changeOrder( string name1, string product1, string nub1, string pri1,string aa)    
        {
            foreach (OrderDet a in myOrd)
            {
                a.name = name1;
                a.nub = nub1;
                a.product = product1;
                a.nub = nub1;
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
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product + "  price:" + q.price);
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
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product + "  price:" + q.price);
            }
        }


    }
}
