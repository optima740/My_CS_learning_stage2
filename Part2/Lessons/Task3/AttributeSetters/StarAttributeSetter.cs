using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    class StarAttributeSetter : ModelAttributeSetter
    {

        protected override void SetNewAttributs(SpaceObject spaceObj, IOutput printInConsole, IInput readFromConsole)
        {
            var star = spaceObj as Star;
            printInConsole.WriteLine($"Степень свечения звезды{star.Name} , *10^3 erg/s: ");
            star.TypeObj = "Star";
            star.DegOfIllumination = Convert.ToSingle(readFromConsole.ReadLine());            
        }
    }    
}
