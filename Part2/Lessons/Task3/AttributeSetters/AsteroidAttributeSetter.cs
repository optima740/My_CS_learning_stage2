using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    class AsteroidAttributeSetter : ModelAttributeSetter
    {
 
        protected override void SetNewAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole)
        {
            var asteroid = spaceObj as Asteroid;
            printInConsole.WriteLine($"Введите скорость астероида {asteroid.Name} , 10^6 м/s: ");
            asteroid.TypeObj = "Asteroid";
            asteroid.Speed = Convert.ToSingle(readFromConsole.ReadLine());
        }
    }
}
