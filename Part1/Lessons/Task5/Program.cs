using System;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            SwapVariables(13, -22);
            Console.ReadKey(true);
        }

        static void SwapVariables(int x, int y)
        {
            Console.WriteLine($"1. До замены: ");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");

            var temp = x;
            x = y;
            y = temp;

            Console.WriteLine($"1. После замены с использованием временной переменной: ");
            Console.WriteLine($"x = {x}");
            Console.WriteLine($"y = {y}");
            Console.WriteLine("________________________________________________________");
            Console.WriteLine($"2. До замены: ");

            int a = y;
            int b = x;

            Console.WriteLine($"x = {a}");
            Console.WriteLine($"y = {b}");

            a = b - a;
            b = b - a;
            a = a + b;

            Console.WriteLine($"2. После замены без использованием временной переменной: ");
            Console.WriteLine($"x = {a}");
            Console.WriteLine($"y = {b}");
        }
    }
}
