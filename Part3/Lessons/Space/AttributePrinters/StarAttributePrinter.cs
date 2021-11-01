using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    public class StarAttributePrinter : ModelAttributePrinter
    {
        public StarAttributePrinter(IOutput printInConsole) : base(printInConsole) { }
        public override void PrintNewAttributs(SpaceObject spaceObj)
        {          
            var star = spaceObj as Star;          
            _printInConsole.WriteLine($"Степень свечения, *10^3 erg/s: {star.DegOfIllumination} \n");
        }
    }
}
