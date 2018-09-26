using System;

namespace homework3
{
    class Program
    {
        static void Main(string[] args)
        {           
            //三角形
            Shape myShip1 = ShapeFactory.CreatShape("Triangle");
            //打印出面积
            myShip1.GetS();

            //圆
            Shape myShip2 = ShapeFactory.CreatShape("Circle");
            myShip2.GetS();

            //正方形
            Shape myShip3 = ShapeFactory.CreatShape("Square");
            myShip3.GetS();

            //矩形
            Shape myShip4 = ShapeFactory.CreatShape("Rectangle");
            myShip4.GetS();

        }
    }
     
    //工厂
    public class ShapeFactory
    {
        public static Shape CreatShape(string type)
        {
            Shape myShape = null;
            if (type.Equals("Triangle"))
            {
                myShape = new Triange();
            }
            else if (type.Equals("Circle"))
            {
                myShape = new Circle();
            }
            else if (type.Equals("Square"))
            {
                myShape = new Square();
            }
            else
            {
                myShape = new Rectangle();
            }
            return myShape;
        }
    }


    //图形抽象类
    public abstract class Shape
    {
        public float r, d, h;
        //输出面积大小
        public abstract void GetS();
    }

    //三角形
    public class Triange : Shape
    {
        public float r = 0F;
        public float d = 3.0F;
        public float h = 2.0F;
        public override void GetS()
        {
            Console.WriteLine("Draw triange,the area is:" + (d * h / 2));
        }
    }
     //圆
    public class Circle : Shape
    {
        public float r = 2.0F;
        public float d = 0;
        public float h = 0;
        public override void GetS()
        {
            Console.WriteLine("Draw Cricle,the area is:" + (3.1415 * r * r));
        }
    }
    //正方形
    public class Square : Shape
    {
        public float r = 0;
        public float d = 4;
        public float h = 4;
         public override void GetS()
         {
             Console.WriteLine("Draw Square,the area is:" + (d * h));
          }
     }
    //矩形
    public class Rectangle : Shape
    {
        public float r = 0;
        public float d = 3;
        public float h = 4;
        public override void GetS()
        {
            Console.WriteLine("Draw Square,the area is:" + (d * h));
        }
    }

    
}
 