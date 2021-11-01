using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxMinOfNumbers(0, -1, 1, 10);
            Console.ReadKey(true);
        }
        static void MaxMinOfNumbers(int a, int b, int c, int d)
        {          
            int max1 = a;
            int min1 = b;
            int max2 = c;
            int min2 = d;            
            int resMax;
            int resMin;

            if (a <= b)
            {
                min1 = a;
                max1 = b;
            }

            if (c <= d)
            {
                min2 = c;
                max2 = d;
            }

            resMax = (max1 <= max2) ? max2 : max1;
            resMin = (min1 >= min2) ? min2 : min1;

            Console.WriteLine($"Min = {resMin}");
            Console.WriteLine($"Max = {resMax}");
        }
    }
}
