using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSegmentNumbers();
            Console.ReadKey(true);
        }

        static void PrintSegmentNumbers()
        {
            for (int i = 1; i < 100; i++)
            {
                if ((i % 3) == 0)
                {
                    Console.WriteLine(i);
                }   
            }
        }
    }
}
