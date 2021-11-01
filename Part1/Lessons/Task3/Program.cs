using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            SumRandomNumbers();
            Console.ReadKey(true);
        }
        static void SumRandomNumbers()
        {
            Random rand = new Random();
            int result = 0;
            int count = 0;

            for (int i = 1; i < 5; i++)
            {
                var rnd = rand.Next(1, 900);
                Console.WriteLine($"Random number {i} = {rnd}");
                result += rnd;
            }
            Console.WriteLine($"Summ Random = {result}");

            while (result > 0)
            {
                result = result / 10;
                count++;
            }
            Console.WriteLine($"Number of digits in Summ = {count}");
        }


    }
}
