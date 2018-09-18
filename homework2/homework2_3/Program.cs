using System;

namespace homework2_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[99];
            for(int i = 0;i <= 98; i++)       //将2 - 99放入数组中
            {
                a[i] = i + 2;
            }
            bool[] ispri = new bool[99];
            for (int i = 0; i <= 98; i++)       
                ispri[i] = true;
            for (int j = 2; j <= 100; j++)
            {
                if(ispri[j - 2] == true)
                {
                    Console.WriteLine(a[j - 2]);
                    for(int m = 2 * j; m <= 100; m += j)
                    {
                        ispri[m - 2] = false;
                    }
                }
            }
        }
    }
}
