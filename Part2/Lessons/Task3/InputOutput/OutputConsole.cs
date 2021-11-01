using System;

namespace Space.InputOutput
{
    class OutputConsole : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
