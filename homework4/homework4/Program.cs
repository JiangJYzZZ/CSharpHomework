using System;

namespace homework4
{
    //委托类型
    public delegate void ClockHandler(object sender, int e);

    //定义事件源
    public class Clock
    {
        //声明事件
        public event ClockHandler Clocking;
        public void DoClock()
        {
            int b = 8;   //8点闹铃
            int a = 25;  
            while (a != b)
            a = DateTime.Now.Hour;
           
            if(Clocking != null)
            Clocking(this, b);
        }
    }


    class Program
    {
        static void Main()
        {
            Console.WriteLine("Sleep...");
            var myClock = new Clock();
            //注册
            myClock.Clocking += WakeUp;
            myClock.DoClock();
        }
        static void WakeUp(object sender, int e)
        {
            Console.WriteLine("This is " + e + "! Get up!");
        }
    }

}
