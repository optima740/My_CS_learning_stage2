using Space.AttributePrinters;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;
using System.Linq;

namespace Space.Operations
{
    class PrintAllObjectsOperation : BasePrintAllOperation
    {

        public PrintAllObjectsOperation(IPrint printer, IOutput printInConsole) : base(printer, printInConsole) { }

        protected override List<SpaceObject> GetObjects(SpaceObjectCollection collection)
        {
            var objectsCollection = collection.GetAllObjects();
                       
            if (objectsCollection.Any())
            {
                objectsCollection.Sort((x, y) => y.TypeObj.CompareTo(x.TypeObj));
                var spaceObjectsSorted = from item in objectsCollection
                                         orderby item.TypeObj
                                         group item by new { item.TypeObj, item.Name };
            }

            return objectsCollection;
        }
    }
}   

