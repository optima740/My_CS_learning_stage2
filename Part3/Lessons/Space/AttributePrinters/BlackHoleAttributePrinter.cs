using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    public class BlackHoleAttributePrinter : ModelAttributePrinter
    {
        public BlackHoleAttributePrinter(IOutput printInConsole) : base(printInConsole) { }
        public override void PrintNewAttributs(SpaceObject spaceObj)
        {
            var blackHole = spaceObj as BlackHole;
            _printInConsole.WriteLine($"Плотность, *10^6 м/s: {blackHole.Density} \n");
        }
    }
}
