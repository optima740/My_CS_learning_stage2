using System;
using System.Collections.Generic;
using System.IO;

namespace Task1
{
    class Program1
    {
        static void Main(string[] args)
        {
            string pathToFile = "File1.txt";

            if (File.Exists(pathToFile))
            {
                while(true)
                {
                    Console.WriteLine("Введите слово для поиска строки \n");
                    string finderWord = Console.ReadLine();
                    FileReader fr = new FileReader(pathToFile);
                    LineFinder lf = new LineFinder();
                    List<string> lines = lf.GetLine(fr, finderWord);
                    if (lines.Count > 0)
                    {
                        Console.WriteLine("_________________________________ \n");
                        foreach (string line in lines)
                        {
                            Console.WriteLine(line);
                        }
                        Console.WriteLine("_________________________________ \n");
                    }
                    else
                    {
                        Console.WriteLine("Строка с указанным словом не найдена \n");
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден \n");
            }
            Console.ReadKey(true);
        }
    }
}