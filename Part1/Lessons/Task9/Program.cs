using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetCountDigitOne(123156));
            Console.ReadKey(true);
        }

        static int GetCountDigitOne(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if ((n % 10) == 1)
            {
                return GetCountDigitOne(n / 10) + 1;
            }

            return GetCountDigitOne(n / 10);
        }
    }
}
