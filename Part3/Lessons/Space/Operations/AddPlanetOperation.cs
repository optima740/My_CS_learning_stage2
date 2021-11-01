using Space.AttributeSetters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;

namespace Space.Operations
{
    public class AddPlanetOperation : BaseAddOperation
    {
        public AddPlanetOperation(ISpaceObjectRepository repository, ISetter setter, IOutput printInConsole, IInput readFromConsole) : base(repository, setter, printInConsole, readFromConsole) { }

        protected override SpaceObject CreateModel()
        {
            return new Planet();
        }
    }
}
