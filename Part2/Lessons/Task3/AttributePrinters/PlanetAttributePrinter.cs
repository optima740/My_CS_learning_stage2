using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    class PlanetAttributePrinter : ModelAttributePrinter
    {
        public override void PrintNewAttributs(SpaceObject spaceObj, IOutput printInConsole)
        {
            var planet = spaceObj as Planet;
            printInConsole.WriteLine($"Угол наклона оси, *10^3 erg/s: {planet.TiltAngle} \n");
        }
    }
}
