using Space.InputOutput;
using Space.Models;


namespace Space.AttributePrinters
{
    abstract class ModelAttributePrinter : IPrint
    {
        public void Print(SpaceObject spaceObj, IOutput printInConsole)
        {
            PrintBaseAttributs(spaceObj, printInConsole);
            PrintNewAttributs(spaceObj, printInConsole);
            printInConsole.WriteLine("\n");
        }

        private void PrintBaseAttributs(SpaceObject spaceObj, IOutput printInConsole)
        {
            printInConsole.WriteLine($"Название: {spaceObj.Name} \n");
            printInConsole.WriteLine($"Расстояние до Солнца, *10^6 km: {spaceObj.DistToSun} \n");
            printInConsole.WriteLine($"Вес, *10^6 kg: {spaceObj.Weight} \n");
            printInConsole.WriteLine($"Диаметр, *10^3 km: {spaceObj.Diametr} \n");
        }

        public abstract void PrintNewAttributs(SpaceObject spaceObj, IOutput printInConsole);
    }
}
