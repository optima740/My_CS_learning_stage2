using Space.AttributeSetters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;

namespace Space.Operations
{
    public class AddAsteroidOperation : BaseAddOperation
    {
        public AddAsteroidOperation(ISpaceObjectRepository repository, ISetter setter, IOutput printInConsole, IInput readFromConsole) : base(repository, setter, printInConsole, readFromConsole) { }

        protected override SpaceObject CreateModel()
        {
            return new Asteroid();          
        }   
    }
}
