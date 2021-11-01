using Space.InputOutput;
using Space.Models;
using System;

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
            asteroid.Speed = Convert.ToSingle(_readFromConsole.ReadLine());
        }
    }
}
