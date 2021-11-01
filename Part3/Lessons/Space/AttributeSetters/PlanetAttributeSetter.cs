using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    public class PlanetAttributeSetter : ModelAttributeSetter
    {
        public PlanetAttributeSetter(IOutput printInConsole, IInput readFromConsole) : base(printInConsole, readFromConsole) { }

        protected override void SetNewAttributs(SpaceObject spaceObj)
        {
            var planet = spaceObj as Planet;
            _printInConsole.WriteLine($"Введите угол наклона оси планеты {planet.Name} , *10^3 erg/s: ");
            planet.TypeObj = "Planet";
            planet.TiltAngle = Convert.ToSingle(_readFromConsole.ReadLine());
        }
    }
}