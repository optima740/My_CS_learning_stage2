using Space.AttributeSetters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using System;
using System.Threading.Tasks;

namespace Space.Operations
{
    public abstract class BaseAddOperation : IOperation
    {
        protected IOutput _printInConsole;
        protected IInput _readFromConsole;
        protected ISetter _setter;
        protected ISpaceObjectRepository _repository;

        public BaseAddOperation(ISpaceObjectRepository repository, ISetter setter, IOutput printInConsole, IInput readFromConsole)
        {
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
            _setter = setter;
            _repository = repository;
        }

        public async Task DoOperationAsync()
        {
            try
            {
                var model = CreateModel();
                _setter.SetAttributs(model);
                await _repository.InsertAsync(model);
            }
            catch (Exception ex)
            {
                _printInConsole.WriteLine(ex.Message);
                return;
            }

            await _repository.SaveAsync();
        }

        protected abstract SpaceObject CreateModel();
    }
}
