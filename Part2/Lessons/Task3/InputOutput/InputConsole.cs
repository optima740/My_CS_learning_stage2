using System;

namespace Space.InputOutput
{
    class InputConsole : IInput
    {        
        public string ReadLine()
        {
            return Console.ReadLine();
        }
        public float ReadFloat()
        {
            return Single.Parse(Console.ReadLine());
        }

        public int ReadInt()
        {
            return Int32.Parse(Console.ReadLine());
        }
    }
}
