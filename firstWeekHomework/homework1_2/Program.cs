using System;

namespace homework1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            int n, m;
            Console.Write("Plesase input a number:");
            s = Console.ReadLine();
            n = Int32.Parse(s);
            Console.Write("Plesase input another number:");
            s = Console.ReadLine();
            m = Int32.Parse(s);
            Console.WriteLine("Their product is " + (n * m));
        }
    }
}
