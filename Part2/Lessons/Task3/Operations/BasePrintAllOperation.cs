using Space.AttributePrinters;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;
using System.Linq;

namespace Space.Operations
{
    abstract class BasePrintAllOperation : IOperation
    {       
        protected IPrint _printer;               
        protected IOutput _printInConsole;

        public BasePrintAllOperation(IPrint printer, IOutput printInConsole)
        {           
            _printInConsole = printInConsole;
            _printer = printer;          
        }

        public void DoOperation(SpaceObjectCollection collection)
        {
            var objectsCollection = GetObjects(collection);
            if (objectsCollection.Any())
            {
                _printInConsole.WriteLine($"Все объекты по запросу: \n");
                _printInConsole.WriteLine("______________________________________________________________________ \n");

                foreach (var item in objectsCollection)
                {
                    _printer.Print(item, _printInConsole);
                }

                return;
            }

            _printInConsole.WriteLine("Данного типа объекта нет! \n");

        }

        protected abstract List<SpaceObject> GetObjects(SpaceObjectCollection collection);
    }
}
