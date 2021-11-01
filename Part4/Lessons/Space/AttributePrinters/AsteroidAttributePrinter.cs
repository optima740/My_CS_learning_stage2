using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    public class AsteroidAttributePrinter : ModelAttributePrinter
    {
        public AsteroidAttributePrinter(IOutput printInConsole) : base(printInConsole) { }
        public override void PrintNewAttributs(SpaceObject spaceObj)
        {
            var asteroid = spaceObj as Asteroid;
            _printInConsole.WriteLine($"Скорость, *10^6 м/s: {asteroid.Speed} \n");           
        }
    }
}
