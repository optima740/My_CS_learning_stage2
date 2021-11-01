using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    class BlackHoleAttributePrinter : ModelAttributePrinter
    {
        public override void PrintNewAttributs(SpaceObject spaceObj, IOutput printInConsole)
        {
            var blackHole = spaceObj as BlackHole;
            printInConsole.WriteLine($"Плотность, *10^6 м/s: {blackHole.Density} \n");
        }
    }
}
