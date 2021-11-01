using Space.InputOutput;
using Space.Models;
using System;

namespace Space.AttributeSetters
{
    public abstract class ModelAttributeSetter : ISetter
    {
        protected IOutput _printInConsole;
        protected IInput _readFromConsole;

        public ModelAttributeSetter(IOutput printInConsole, IInput readFromConsole)
        {
            _printInConsole = printInConsole;
            _readFromConsole = readFromConsole;
        }

        public void SetAttributs(SpaceObject spaceObj)
        {
            try
            {
                SetBaseAttributs(spaceObj);
                SetNewAttributs(spaceObj);
                _printInConsole.WriteLine("\n");
            }
            catch
            {
                throw new Exception("Вы ввели недопустимое значение, объект не создан!");
            }
        }

        private void SetBaseAttributs(SpaceObject spaceObj)
        {
            _printInConsole.WriteLine("Введите название объекта : ");
            spaceObj.Name = _readFromConsole.ReadLine();
            _printInConsole.WriteLine($"Введите расстояние от {spaceObj.Name} до солнца, *10^6 km: ");
            spaceObj.DistToSun = Convert.ToSingle(_readFromConsole.ReadLine());
            _printInConsole.WriteLine($"Введите вес {spaceObj.Name} , *10^6 kg: ");
            spaceObj.Weight = Convert.ToSingle(_readFromConsole.ReadLine());
            _printInConsole.WriteLine($"Введите диаметр {spaceObj.Name} , km: ");
            spaceObj.Diametr = Convert.ToSingle(_readFromConsole.ReadLine());
        }

        protected abstract void SetNewAttributs(SpaceObject spaceObj);
    }
}