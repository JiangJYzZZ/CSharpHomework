using System;
using System.Linq;

namespace homework5
{
    class Oreder
    {
        static void Main(string[] args)
        {
            OrderSev mySev = new OrderSev();

            //实例化10个订单存储空间
            for (int k = 0; k < 10; k++)
                mySev.List[k] = new OrderDet();

            //新建3个
            mySev.newOrder("Jane", "water", "1102",100);
            mySev.newOrder("Cool", "phone", "1103",20000);
            mySev.newOrder("Janny", "computer", "1106", 40000);


            //使用Linq 通过名字查找
            mySev.findOrderLinqName("Jane");


            Console.WriteLine("Price >= 10000:");
            //大于10000
            mySev.findOrderLinqPri(10000);

        }
    }

    class OrderDet
    {
        public string name = "0";            //客户名，产品名,订单号  
        public string product = "0";
        public string nub = "0";
        public int price = 0;


    }

    class OrderSev
    {
        public OrderDet[] List = new OrderDet[10];     //给10个空间


        //添加
        public void newOrder(string yname, string yproduct, string ynub,int ypri)  //传入新商品信息
        {
            int op = 0;

            while (this.List[op].nub != "0" && op < 10)
            {
                op++;
                Console.WriteLine(this.List[op].nub);
            }

            if (op < 10)
            {
                List[op].name = yname;
                List[op].nub = ynub;
                List[op].product = yproduct;
                List[op].price = ypri;
                Console.WriteLine("Success");
            }
            else
                Console.WriteLine("Please create a bigger List!");
        }


        //删除
        public void deOrder(string a)  //按订单号删除
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
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message + "没有这个订单");
            }

        }

        public void findOrderNub(string n)     //按订单号查找
        {
            int i = 0;
            try
            {
                while (List[i].nub != n)
                    i++;
                Console.WriteLine("Name:" + List[i].name + "  Product:" + List[i].product + "  Number:" + List[i].nub);
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Not Find!");
            }

        }

        public void findOrderName(string n)     //按名字查找
        {
            int i = 0;
            try
            {
                while (List[i].name != n)
                    i++;
                Console.WriteLine("Name:" + List[i].name + "  Product:" + List[i].product + "  Number:" + List[i].nub + "  Price:"+ List[i].price);

            }
            catch (System.IndexOutOfRangeException)
            {
                Console.WriteLine("Not Find!");
            }

        }

        //修改
        public void changeOrder(string n, string name1, string product1, string nub1 ,int pri1)    //按订单号修改数据,传入需修改的数据
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
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //使用Linq查询

        public void findOrderLinqName(string n)     //传入客户名
        {
            var m = from x in List
                    where x.name == n
                    select x;
            foreach(var q in m)
            {
                Console.WriteLine("name:" + q.name + " number:" + q.nub + " product:" + q.product +"  price:" + q.price);
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
    }

}
