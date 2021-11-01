using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    class PlanetAttributeSetter : ModelAttributeSetter
    {
      
        protected override void SetNewAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole)
        {
            var planet = spaceObj as Planet;
            printInConsole.WriteLine($"Введите угол наклона оси планеты {planet.Name} , *10^3 erg/s: ");
            planet.TypeObj = "Planet";
            planet.TiltAngle = Convert.ToSingle(readFromConsole.ReadLine());
        }
    }
}
