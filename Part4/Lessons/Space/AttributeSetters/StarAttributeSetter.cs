using Space.InputOutput;
using Space.Models;

namespace Space.AttributeSetters
{
    public class StarAttributeSetter : ModelAttributeSetter
    {
        public StarAttributeSetter(IOutput printInConsole, IInput readFromConsole) : base(printInConsole, readFromConsole) { }

        protected override void SetNewAttributs(SpaceObject spaceObj)
        {
            var star = spaceObj as Star;
            _printInConsole.WriteLine($"Степень свечения звезды{star.Name} , *10^3 erg/s: ");
            star.TypeObj = "Star";
            star.DegOfIllumination = _readFromConsole.ReadFloat();
        }
    }    
}