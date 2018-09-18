using System;

namespace homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Plesase input a number:");
            string s = Console.ReadLine();
            int k = Int32.Parse(s);
            for(int i = 2; i <= k; i++)
            {
                if(k % i == 0)
                {
                    k = k / i;
                    for(int j = 2;j < i;j = j + 1)
                    {
                        if (i % j == 0)
                            goto outer;
                    }
                    Console.Write(i + " ");
                    i = i - 1;
                }
            outer:;
            }
        }
    }
}
