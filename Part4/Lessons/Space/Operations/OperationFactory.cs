using Space.AttributePrinters;
using Space.InputOutput;
using System.Collections.Generic;
using Space.AttributeSetters;
using Space.DataAccessLayer;

namespace Space.Operations
{
    public class OperationFactory
    {      
        private IOutput _printInConsole;
        private IInput _readFromConsole;
        private Dictionary<int, IOperation> _dictOperations;
        private ISpaceObjectRepository _repository;

        public OperationFactory(ISpaceObjectRepository repository, IOutput printInConsole, IInput readFromConsole)
        {          
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
            _repository = repository;
            _dictOperations = new Dictionary<int, IOperation>
            {
                [0] = new PrintAllObjectsOperation(_repository, new AllSpaceObjectsPrinter(printInConsole), _printInConsole),
                [1] = new AddStarOperation(_repository, new StarAttributeSetter(printInConsole, readFromConsole), _printInConsole, _readFromConsole),
                [2] = new AddPlanetOperation(_repository, new PlanetAttributeSetter(printInConsole, readFromConsole), _printInConsole, _readFromConsole),
                [3] = new AddAsteroidOperation(_repository, new AsteroidAttributeSetter(printInConsole, readFromConsole), _printInConsole, _readFromConsole),
                [4] = new AddBlackHoleOperation(_repository, new BlackHoleAttributeSetter(printInConsole, readFromConsole), _printInConsole, _readFromConsole),
                [5] = new PrintAllStarsOperation(_repository, new StarAttributePrinter(printInConsole), _printInConsole),
                [6] = new PrintAllPlanetsOperation(_repository, new PlanetAttributePrinter(printInConsole), _printInConsole),
                [7] = new PrintAllAsteroidsOperation(_repository, new AsteroidAttributePrinter(printInConsole), _printInConsole),
                [8] = new PrintAllBlackHolesOperation(_repository, new BlackHoleAttributePrinter(printInConsole), _printInConsole),
                [9] = new RemoveObjectOperation(_repository, _printInConsole, _readFromConsole)
            };
        }

        public IOperation GetOperation(int command)
        {
            return _dictOperations[command];
        }
    }
}
