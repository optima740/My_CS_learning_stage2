using Space.InputOutput;
using Space.Operations;
using System;

namespace Space
{
    class CommandHandler
    {     
        protected enum _userCommands
        {
            PrintAllObjects,
            AddStar,
            AddPlanet,
            AddAsteroid,
            AddBlackHole,
            PrintStars,
            PrintPlanets,
            PrintAsteroids,
            PrintBlackHoles,
            RemoveObject
        };

        public void Execute()
        {
            var printInConsole = new OutputConsole();
            var readFromConsole = new InputConsole();
            var spaceObjectCollection = new SpaceObjectCollection();
            var operationFactory = new OperationFactory(printInConsole, readFromConsole);
            printInConsole.WriteLine("______________________________________________________________________ \n");
            printInConsole.WriteLine("Вас приветствует информационная система космических объектов \"СОЮЗ\"!");
            int command;
            
            while (true)
            {
                ShowCommand(printInConsole);
                string userInput = readFromConsole.ReadLine();
                
                if ((Int32.TryParse(userInput, out command)) && (Enum.IsDefined(typeof(_userCommands), command)))
                {
                    var operation = operationFactory.GetOperation(command);
                    operation.DoOperation(spaceObjectCollection);
                }
                else
                {
                    printInConsole.WriteLine("Вы ввели недопустимую команду!");
                }               
            }
        }

        public void ShowCommand(IOutput printInConsole)
        {
            printInConsole.WriteLine("______________________________________________________________________ \n");
            printInConsole.WriteLine($"Введите комманду из списка: \n");
            printInConsole.WriteLine($"1 - Для добавления нового объекта STAR \n");
            printInConsole.WriteLine($"2 - Для добавления нового объекта PLANET \n");
            printInConsole.WriteLine($"3 - Для добавления нового объекта ASTEROID \n");
            printInConsole.WriteLine($"4 - Для добавления нового объекта BLACKHOLE  \n");
            printInConsole.WriteLine($"5 - Для просмотра всех объектов STAR  \n");
            printInConsole.WriteLine($"6 - Для просмотра всех объектов PLANET  \n");
            printInConsole.WriteLine($"7 - Для просмотра всех объектов ASTEROID  \n");
            printInConsole.WriteLine($"8 - Для просмотра всех объектов BLACKHOLE  \n");
            printInConsole.WriteLine($"9 - Для удаления объекта \n");
            printInConsole.WriteLine($"0 - Для просмотра всех имеющихся объектов \n");
            printInConsole.WriteLine("______________________________________________________________________ \n");
        }
    }
}
