using Space.AttributePrinters;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;

namespace Space.Operations
{
    class PrintAllPlanetsOperation : BasePrintAllOperation
    {
        public PrintAllPlanetsOperation(ModelAttributePrinter printer, IOutput printInConsole) : base(printer, printInConsole) { }

        protected override List<SpaceObject> GetObjects(SpaceObjectCollection collection)
        {
            return collection.GetAllObjectsByType<Planet>();
        }
    }
}
