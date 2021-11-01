using Space.AttributeSetters;
using Space.DataAccessLayer;
using Space.InputOutput;
using Space.Models;
using System;

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

        public void DoOperation()
        {
            try
            {
                var model = CreateModel();
                _setter.SetAttributs(model);
                _repository.Insert(model);
            }
            catch (Exception ex)
            {
                _printInConsole.WriteLine(ex.Message);
                return;
            }

            _repository.Save();
        }

        protected abstract SpaceObject CreateModel();
    }
}
