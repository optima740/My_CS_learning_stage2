using Space.FileConnections;
using Space.InputOutput;
using Space.Models;
using System;
using Space.AttributeSetters;

namespace Space.Operations
{
    abstract class BaseAddOperation : IOperation
    {
        protected IOutput _printInConsole;
        protected IInput _readFromConsole;
        protected ModelAttributeSetter _setter;
        public BaseAddOperation(ModelAttributeSetter setter, IOutput printInConsole, IInput readFromConsole)
        {
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
            _setter = setter;
        }

        public void DoOperation(SpaceObjectCollection collection)
        {
            try
            {
                var model = CreateModel();
                _setter.SetAttributs(model, _printInConsole, _readFromConsole);
                collection.AddToCollection(model);
            }
            catch (Exception ex)
            {
                _printInConsole.WriteLine(ex.Message);
                return;
            }

            JsonSaver.SaveToFile(collection.GetAllObjects());
        }

        protected abstract SpaceObject CreateModel();
    }
}
