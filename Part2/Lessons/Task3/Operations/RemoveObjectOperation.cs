using Space.FileConnections;
using Space.InputOutput;

namespace Space.Operations
{
    class RemoveObjectOperation : IOperation
    {
       
        private IOutput _printInConsole;
        private IInput _readFromConsole;
        
        public RemoveObjectOperation(IOutput printInConsole, IInput readFromConsole)
        {
           
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
        }
        
        public void DoOperation(SpaceObjectCollection collection)
        {
            _printInConsole.WriteLine("Введите имя объекта, который необходимо удалить: \n");
            string name = _readFromConsole.ReadLine();

            if (collection.IsContains(name))
            {
                collection.RemoveFromCollection(name);
                JsonSaver.SaveToFile(collection.GetAllObjects());
                _printInConsole.WriteLine("Объект удален!\n");
                return;
            }
            
            _printInConsole.WriteLine("Объект с указанным именем не найден! \n");         
        }
    }
}
