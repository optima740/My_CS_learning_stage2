using Space.DataAccessLayer;
using Space.InputOutput;

namespace Space.Operations
{
    public class RemoveObjectOperation : IOperation
    {      
        private IOutput _printInConsole;
        private IInput _readFromConsole;
        private ISpaceObjectRepository _repository;

        public RemoveObjectOperation(ISpaceObjectRepository repository, IOutput printInConsole, IInput readFromConsole)
        {           
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
            _repository = repository;
        }
        
        public void DoOperation()
        {
            _printInConsole.WriteLine("Введите имя объекта, который необходимо удалить: \n");
            string name = _readFromConsole.ReadLine();

            if (_repository.IsContains(name))
            {
                var spaceObj = _repository.Get(name);
                _repository.Delete(spaceObj.id);
                _repository.Save();
                _printInConsole.WriteLine("Объект удален!\n");
                return;
            }
            
            _printInConsole.WriteLine("Объект с указанным именем не найден! \n");         
        }
    }
}
