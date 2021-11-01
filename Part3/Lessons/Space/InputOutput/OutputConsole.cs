using System;

namespace Space.InputOutput
{
    public class OutputConsole : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
