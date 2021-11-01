using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    abstract class ModelAttributeSetter
    {
       
        public void SetAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole)
        {
            try
            {
                SetBaseAttributs(spaceObj, printInConsole, readFromConsole);
                SetNewAttributs(spaceObj, printInConsole, readFromConsole);
                printInConsole.WriteLine("\n");
            }
            catch
            {
                throw new Exception("Вы ввели недопустимое значение, объект не создан!");
            }
        }

        private void SetBaseAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole)
        {
            printInConsole.WriteLine("Введите название объекта : ");
            spaceObj.Name = readFromConsole.ReadLine();
            printInConsole.WriteLine($"Введите расстояние от {spaceObj.Name} до солнца, *10^6 km: ");
            spaceObj.DistToSun = Convert.ToSingle(readFromConsole.ReadLine());
            printInConsole.WriteLine($"Введите вес {spaceObj.Name} , *10^6 kg: ");
            spaceObj.Weight = Convert.ToSingle(readFromConsole.ReadLine());
            printInConsole.WriteLine($"Введите диаметр {spaceObj.Name} , km: ");
            spaceObj.Diametr = Convert.ToSingle(readFromConsole.ReadLine());
        }

        protected abstract void SetNewAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole);
    }
}
