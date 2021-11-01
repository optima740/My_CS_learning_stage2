using Space.AttributePrinters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;

namespace Space.Operations
{
    public class PrintAllPlanetsOperation : BasePrintAllOperation
    {
        public PrintAllPlanetsOperation(ISpaceObjectRepository repository, IPrinter printer, IOutput printInConsole) : base(repository, printer, printInConsole) { }

        protected override IAsyncEnumerable<SpaceObject> GetObjects()
        {           
            return _repository.GetAllByTypeAsync<Planet>();
        }
    }
}
