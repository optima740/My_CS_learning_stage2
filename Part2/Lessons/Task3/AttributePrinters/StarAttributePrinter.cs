using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    class StarAttributePrinter : ModelAttributePrinter
    {
        public override void PrintNewAttributs(SpaceObject spaceObj, IOutput printInConsole)
        {          
            var star = spaceObj as Star;          
            printInConsole.WriteLine($"Степень свечения, *10^3 erg/s: {star.DegOfIllumination} \n");
        }
    }
}
