using Space.AttributePrinters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;
using System.Linq;

namespace Space.Operations
{
    public abstract class BasePrintAllOperation : IOperation
    {
        protected IPrinter _printer;
        protected IOutput _printInConsole;
        protected ISpaceObjectRepository _repository;

        public BasePrintAllOperation(ISpaceObjectRepository repository, IPrinter printer, IOutput printInConsole)
        {
            _printInConsole = printInConsole;
            _printer = printer;
            _repository = repository;
        }

        public void DoOperation()
        {
            var objectsCollection = GetObjects();
            
            if (objectsCollection.Any())
            {
                _printInConsole.WriteLine($"Все объекты по запросу: \n");
                _printInConsole.WriteLine("______________________________________________________________________ \n");

                foreach (var item in objectsCollection)
                {
                    _printer.Print(item);
                }

                return;
            }

            _printInConsole.WriteLine("Данного типа объекта нет! \n");
        }

        protected abstract IEnumerable<SpaceObject> GetObjects();
    }
}
