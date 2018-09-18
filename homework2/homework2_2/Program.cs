using System;

namespace homework2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 3, 8, 4, 8, 8 };
            int min = a[0], max = a[0], sum = 0;
            foreach(int i in a)
            {
                if (min > i)
                    min = i;
                if (max < i)
                    max = i;
                sum = sum + i;
            }
            float length = a.Length/1.0F;
            float avg = sum / length;
            Console.WriteLine("max :" + max);
            Console.WriteLine("min :" + min);
            Console.WriteLine("avg :" + avg);
            Console.WriteLine("sum :" + sum);
        }
    }
}
