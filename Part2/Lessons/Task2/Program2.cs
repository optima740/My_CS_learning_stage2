using System;

namespace Task2
{
    class Program2
    {
        static void Main(string[] args)
        {
            MyStack<string> stack = new MyStack<string>();
            stack.Notify += DisplayMessage;
            stack.Push("один");
            stack.Push("два");
            stack.Push("три");
            stack.Push("четыре");
            stack.Push("пять");
            stack.Push("шесть");
            stack.Push("семь");
            stack.Push("восемь");
            stack.Push("девять");
            stack.Push("десять");
            stack.Push("одинадцать");
            Console.WriteLine();
            Console.WriteLine($"размер стека: {stack.GetLength()}");         
            
            try
            {
                Console.WriteLine();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
                stack.Pop();
            }
            catch
            {
                Console.WriteLine("пустой стек");
            }
            Console.WriteLine();
            Console.WriteLine($"размер стека: {stack.GetLength()}");
            Console.ReadKey(true);
        }

        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
