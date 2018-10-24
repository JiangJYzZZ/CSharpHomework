using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace homework6.text
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()                    //添加的测试
        {
            OrderSev my = new OrderSev();
            
            //实例化3个订单存储空间
            for (int k = 0; k < 3; k++)
                my.List[k] = new OrderDet();
            //新建3个
            bool a = my.newOrder("Jane", "water", "1102", 100);
            Assert.IsTrue(a);         //测试成功例子
        }

        [TestMethod]
        public void TestMethod2()                    //删除的测试
        {
            OrderSev my = new OrderSev();

            //实例化3个订单存储空间
            for (int k = 0; k < 3; k++)
                my.List[k] = new OrderDet();
            //新建3个
            my.newOrder("Jane", "water", "1102", 100);
            bool b = my.deOrder("1101");
            Assert.IsTrue(b);                //测试失败例子
        }

        [TestMethod]
        public void TestMethod3()                    //查找的测试
        {
            OrderSev my = new OrderSev();

            //实例化3个订单存储空间
            for (int k = 0; k < 3; k++)
                my.List[k] = new OrderDet();
            //新建3个
            my.newOrder("Jane", "water", "1102", 100);
            bool b = my.findOrderNub("1102");
            Assert.IsTrue(b);                
        }

        [TestMethod]
        public void TestMethod4()                    //修改的测试
        {
            OrderSev my = new OrderSev();

            //实例化3个订单存储空间
            for (int k = 0; k < 3; k++)
                my.List[k] = new OrderDet();
            //新建3个
            my.newOrder("Jane", "water", "1102", 100);
            bool b = my.changeOrder("1102", "me", "water", "2211", 1000);
            Assert.IsTrue(b);
        }
    }
}
