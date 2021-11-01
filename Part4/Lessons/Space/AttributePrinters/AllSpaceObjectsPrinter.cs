using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    public class AllSpaceObjectsPrinter : IPrinter
    {
        protected IOutput _printInConsole;
        public AllSpaceObjectsPrinter(IOutput printInConsole)
        {
            _printInConsole = printInConsole;
        }
        public void Print(SpaceObject spaceObj)
        {              
            _printInConsole.WriteLine($"объект типа {spaceObj.TypeObj}, с именем {spaceObj.Name} \n");           
        }
    }
}
