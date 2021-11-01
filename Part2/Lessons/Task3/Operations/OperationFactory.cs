using Space.AttributePrinters;
using Space.InputOutput;
using System.Collections.Generic;
using Space.AttributeSetters;

namespace Space.Operations
{
    class OperationFactory
    {      
        private IOutput _printInConsole;
        private IInput _readFromConsole;
        private Dictionary<int, IOperation> _dictOperations;
        
        public OperationFactory(IOutput printInConsole, IInput readFromConsole)
        {
           
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
            _dictOperations = new Dictionary<int, IOperation>
            {
                [0] = new PrintAllObjectsOperation(new AllSpaceObjectsPrinter(), _printInConsole),
                [1] = new AddStarOperation(new StarAttributeSetter(), _printInConsole, _readFromConsole),
                [2] = new AddPlanetOperation(new PlanetAttributeSetter(), _printInConsole, _readFromConsole),
                [3] = new AddAsteroidOperation(new AsteroidAttributeSetter(), _printInConsole, _readFromConsole),
                [4] = new AddBlackHoleOperation(new BlackHoleAttributeSetter(), _printInConsole, _readFromConsole),
                [5] = new PrintAllStarsOperation(new StarAttributePrinter(), _printInConsole),
                [6] = new PrintAllPlanetsOperation(new PlanetAttributePrinter(), _printInConsole),
                [7] = new PrintAllAsteroidsOperation(new AsteroidAttributePrinter(), _printInConsole),
                [8] = new PrintAllBlackHolesOperation(new BlackHoleAttributePrinter(), _printInConsole),
                [9] = new RemoveObjectOperation(_printInConsole, _readFromConsole)
            };
        }

        public IOperation GetOperation(int command)
        {
            return _dictOperations[command];
        }
    }
}
