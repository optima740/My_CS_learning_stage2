using Space.InputOutput;
using Space.Models;

namespace Space.AttributeSetters
{
    public class AsteroidAttributeSetter : ModelAttributeSetter
    {
        public AsteroidAttributeSetter(IOutput printInConsole, IInput readFromConsole) : base(printInConsole, readFromConsole) { }

        protected override void SetNewAttributs(SpaceObject spaceObj)
        {
            var asteroid = spaceObj as Asteroid;
            _printInConsole.WriteLine($"Введите скорость астероида {asteroid.Name} , 10^6 м/s: ");
            asteroid.TypeObj = "Asteroid";
            asteroid.Speed = _readFromConsole.ReadFloat();
        }
    }
}
