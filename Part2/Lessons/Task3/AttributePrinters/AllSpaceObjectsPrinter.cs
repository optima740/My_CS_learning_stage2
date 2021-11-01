using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    class AllSpaceObjectsPrinter : IPrint
    {
        public void Print(SpaceObject spaceObj, IOutput printInConsole)
        {              
            printInConsole.WriteLine($"объект типа {spaceObj.TypeObj}, с именем {spaceObj.Name} \n");           
        }
    }
}
