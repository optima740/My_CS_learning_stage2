using Space.InputOutput;
using Space.Models;

namespace Space.AttributePrinters
{
    interface IPrint
    {
        void Print(SpaceObject spaceObj, IOutput printInConsole);
    }
}
