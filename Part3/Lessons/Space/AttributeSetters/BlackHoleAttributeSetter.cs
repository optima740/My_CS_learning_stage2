using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    public class BlackHoleAttributeSetter : ModelAttributeSetter
    {
        public BlackHoleAttributeSetter(IOutput printInConsole, IInput readFromConsole) : base(printInConsole, readFromConsole) { }

        protected override void SetNewAttributs(SpaceObject spaceObj)
        {
            var blackHole = spaceObj as BlackHole;
            _printInConsole.WriteLine($"Введите плотность звездного вещества {blackHole.Name} , m/V: ");
            blackHole.TypeObj = "BlackHole";
            blackHole.Density = Convert.ToSingle(_readFromConsole.ReadLine());
        }
    }
}
