using System;
using System.Diagnostics;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            GetFiboSequence(41);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
            Console.ReadKey(true);
        }

        static void GetFiboSequence(int k)
        {
            for (int i = 0; i < k + 1; i++)
            {
                Console.WriteLine(DoTailFibo(i, 0, 1));
            }
        }

        static int DoTailFibo(int k, int a, int b)
        {
            if (k == 0)
            {
                return a;
            }

            if (k == 1)
            {
                return b;
            }

            return DoTailFibo(k - 1, b, a + b);
        }
    }
}
