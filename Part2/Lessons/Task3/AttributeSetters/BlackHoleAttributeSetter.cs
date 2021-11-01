using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    class BlackHoleAttributeSetter : ModelAttributeSetter
    {
        protected override void SetNewAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole)
        {
            var blackHole = spaceObj as BlackHole;
            printInConsole.WriteLine($"Введите плотность звездного вещества {blackHole.Name} , m/V: ");
            blackHole.TypeObj = "BlackHole";
            blackHole.Density = Convert.ToSingle(readFromConsole.ReadLine());
        }
    }
}
