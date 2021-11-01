using Space.AttributePrinters;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;

namespace Space.Operations
{
    class PrintAllAsteroidsOperation : BasePrintAllOperation
    {
        public PrintAllAsteroidsOperation(ModelAttributePrinter printer, IOutput printInConsole) : base(printer, printInConsole) { }

        protected override List<SpaceObject> GetObjects(SpaceObjectCollection collection)
        {
            return collection.GetAllObjectsByType<Asteroid>();
        }
    }
}
