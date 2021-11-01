using Space.AttributePrinters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task DoOperationAsync()
        {
            var objectsCollection = GetObjects();

            _printInConsole.WriteLine($"Все объекты по запросу: \n");
            _printInConsole.WriteLine("______________________________________________________________________ \n");

            await foreach (var item in objectsCollection)
            {
                _printer.Print(item);
            }

            return;
        }

        protected abstract IAsyncEnumerable<SpaceObject> GetObjects();
    }
}
