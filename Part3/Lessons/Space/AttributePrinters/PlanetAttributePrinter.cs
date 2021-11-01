using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    public class PlanetAttributePrinter : ModelAttributePrinter
    {
        public PlanetAttributePrinter(IOutput printInConsole) : base(printInConsole) { }

        public override void PrintNewAttributs(SpaceObject spaceObj)
        {
            var planet = spaceObj as Planet;
            _printInConsole.WriteLine($"Угол наклона оси, *10^3 erg/s: {planet.TiltAngle} \n");
        }
    }
}
