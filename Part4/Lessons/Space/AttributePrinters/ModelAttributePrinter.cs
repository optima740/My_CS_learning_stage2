using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    public abstract class ModelAttributePrinter : IPrinter
    {
        protected IOutput _printInConsole;
        public ModelAttributePrinter(IOutput printInConsole)
        {
            _printInConsole = printInConsole;
        }

        public void Print(SpaceObject spaceObj)
        {
            PrintBaseAttributs(spaceObj);
            PrintNewAttributs(spaceObj);
            _printInConsole.WriteLine("\n");
        }

        private void PrintBaseAttributs(SpaceObject spaceObj)
        {
            _printInConsole.WriteLine($"Название: {spaceObj.Name} \n");
            _printInConsole.WriteLine($"Расстояние до Солнца, *10^6 km: {spaceObj.DistToSun} \n");
            _printInConsole.WriteLine($"Вес, *10^6 kg: {spaceObj.Weight} \n");
            _printInConsole.WriteLine($"Диаметр, *10^3 km: {spaceObj.Diametr} \n");
        }

        public abstract void PrintNewAttributs(SpaceObject spaceObj);
    }
}
