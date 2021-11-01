using Space.DataAccessLayer;
using Space.InputOutput;
using System.Threading.Tasks;

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
        
        public async Task DoOperationAsync()
        {
            _printInConsole.WriteLine("Введите имя объекта, который необходимо удалить: \n");
            string name = _readFromConsole.ReadLine();
            var spaceObj = await _repository.GetAsync(name);
            
            if (spaceObj != null)
            {               
                await _repository.DeleteAsync(spaceObj.id);
                await _repository.SaveAsync();
                _printInConsole.WriteLine("Объект удален!\n");
               
                return;
            }
            
            _printInConsole.WriteLine("Объект с указанным именем не найден! \n");         
        }
    }
}
