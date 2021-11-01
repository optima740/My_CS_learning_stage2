using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDivNumbers(5);
            Console.ReadKey(true);
        }

        static void PrintDivNumbers(int k)
        {
            if (k != 0)
            {
                for (int i = 1; i < 100; i++)
                {
                    if ((i % k) == 0)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
