using System;

namespace homework4_2
{
    class Oreder
    {
        static void Main(string[] args)
        {
            OrderSev mySev = new OrderSev();

            //实例化10个订单存储空间
            for(int k = 0; k < 10; k++)
            mySev.List[k] = new OrderDet();

            //新建两个
            mySev.newOrder("Jane", "water", "1102");
            mySev.newOrder("Cool", "phone", "1103");

            //删除一个没有的的订单号
            mySev.deOrder("1104");

            //删除一个订单号
            mySev.deOrder("1102");

            //按订单号查找
            mySev.findOrderNub("1103");
            //查找一个不存在的单号
            mySev.findOrderNub("2133");
            //按名字查找
            mySev.findOrderName("Cool");

            //修改
            mySev.changeOrder("1103", "JiangJy", "Computer","1103");
            mySev.findOrderNub("1103");
        }
    }

    class OrderDet
    {
        public string name = "0";            //客户名，产品名,订单号  
        public string product = "0";
        public string nub = "0";


    }

    class OrderSev
    {
        public OrderDet[] List = new OrderDet[10];     //给10个空间


        //添加
        public void newOrder(string yname, string yproduct, string ynub)  //传入新商品信息
        {
            int op = 0;
            
            while (this.List[op].nub != "0" && op < 10) { op++;
                Console.WriteLine(this.List[op].nub);
            }

            if (op < 10)
            {
                List[op].name = yname;
                List[op].nub = ynub;
                List[op].product = yproduct;
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
            catch (System.IndexOutOfRangeException )
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
                Console.WriteLine("Name:" + List[i].name + "  Product:" + List[i].product + "  Number:" + List[i].nub);

            }
            catch (System.IndexOutOfRangeException )
            {
                Console.WriteLine("Not Find!");
            }

        }

        //修改
        public void changeOrder(string n,string name1,string product1,string nub1 )    //按订单号修改数据,传入需修改的数据
        {
            int i = 0;
            try
            {
                while (List[i].nub != n)
                    i++;
                List[i].name = name1;
                List[i].nub = nub1;
                List[i].product = product1;
                Console.WriteLine("Scuccess");
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }


}  

