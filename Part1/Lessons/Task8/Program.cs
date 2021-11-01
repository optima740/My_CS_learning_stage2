using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetSummNumbers(1234));
            Console.ReadKey(true);
        }

        static int GetSummNumbers(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            return (n % 10) + GetSummNumbers(n / 10);
        }
    }
}
