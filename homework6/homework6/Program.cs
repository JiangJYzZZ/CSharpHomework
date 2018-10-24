using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;


namespace homework6
{
    [Serializable]
    public class Oreder
    {
        static void Main(string[] args)
        {
            OrderSev mySev = new OrderSev();

            //实例化10个订单存储空间
            for (int k = 0; k < 10; k++)
                mySev.List[k] = new OrderDet();

            //新建3个
            mySev.newOrder("Jane", "water", "1102", 100);
            mySev.newOrder("Cool", "phone", "1103", 20000);
            mySev.newOrder("Janny", "computer", "1106", 40000);

            //XMl序列化
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderDet[]));
            String xmlFileName = "myxml.xml";
            OrderSev.Export(xmlser, xmlFileName, mySev.List);

            //XML反序列化
            OrderDet[] a = new OrderDet[10];
            OrderSev.Import(xmlser, xmlFileName, a);


            //遍历打印反序列化出来的结果
            int kl;                                         //得出xml中有几个订单
            for (kl = 0; kl < 10; kl++)
            {
                if (a[kl].name == "0")
                {
                    break;
                }
            }
            for (int i = 0; i < kl; i++)
            {
                Console.WriteLine(a[i].name + " " + a[i].nub + " " + a[i].product);
            }
        }
    }

    public class OrderDet
    {
        public string name = "0";            //客户名，产品名,订单号  
        public string product = "0";
        public string nub = "0";
        public int price = 0;


    }

    public class OrderSev
    {
        public OrderDet[] List = new OrderDet[10];     //给10个空间


        //添加
        public bool newOrder(string yname, string yproduct, string ynub, int ypri)  //传入新商品信息
        {
            int op = 0;

            while (this.List[op].nub != "0" && op < 10)
            {
                op++;
                //Console.WriteLine(this.List[op].nub);
            }

            if (op < 10)
            {
                List[op].name = yname;
                List[op].nub = ynub;
                List[op].product = yproduct;
                List[op].price = ypri;
                Console.WriteLine("New Success");
                return true;
            }
            else
                return false;
        }


        //删除
        public bool deOrder(string a)  //按订单号删除
        {
            int i = 0;
            try
            {
                while (List[i].nub != a)
                    i++;
                List[i].nub = "0";
                List[i].name = "0";
                List[i].product = "0";
                List[i].price = 0;
                Console.WriteLine("Success");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "没有这个订单");
                return false;
            }

        }

        public bool findOrderNub(string n)     //按订单号查找
        {
            int i = 0;
            try
            {
                while (List[i].nub != n)
                    i++;
                Console.WriteLine("Name:" + List[i].name + "  Product:" + List[i].product + "  Number:" + List[i].nub);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not Find!");
                return false;
            }

        }

        public bool findOrderName(string n)     //按名字查找
        {
            int i = 0;
            try
            {
                while (List[i].name != n)
                    i++;
                Console.WriteLine("Name:" + List[i].name + "  Product:" + List[i].product + "  Number:" + List[i].nub + "  Price:" + List[i].price);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Not Find!");
                return false;
            }

        }

        //修改
        public bool changeOrder(string n, string name1, string product1, string nub1, int pri1)    //按订单号修改数据,传入需修改的数据
        {
            int i = 0;
            try
            {
                while (List[i].nub != n)
                    i++;
                List[i].name = name1;
                List[i].nub = nub1;
                List[i].product = product1;
                List[i].price = pri1;
                Console.WriteLine("Scuccess");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }


        //使用Linq查询

        public void findOrderLinqName(string n)     //传入客户名
        {
            var m = from x in List
                    where x.name == n
                    select x;
            foreach (var q in m)
            {
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product + "  price:" + q.price);
            }
        }

        //查询大于10000的订单
        public void findOrderLinqPri(int n)
        {
            var m = from x in List
                    where x.price >= n
                    select x;
            foreach (var q in m)
            {
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product + "  price:" + q.price);
            }
        }

        public static void Export(XmlSerializer ser, string fileName, object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }

        public static void Import(XmlSerializer ser, string fileName, OrderDet[] obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);

            OrderDet[] pl = (OrderDet[])ser.Deserialize(fs);
            for (int i = 0; i < 10; i++)
            {
                obj[i] = pl[i];
            }

        }

    }
}
