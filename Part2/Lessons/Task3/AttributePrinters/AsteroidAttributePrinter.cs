using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    class AsteroidAttributePrinter : ModelAttributePrinter
    {
        public override void PrintNewAttributs(SpaceObject spaceObj, IOutput printInConsole)
        {
            var asteroid = spaceObj as Asteroid;
            printInConsole.WriteLine($"Скорость, *10^6 м/s: {asteroid.Speed} \n");           
        }
    }
}
