using System;

namespace Task2
{
    class MyStack<T>
    {
        private T[] _stack;
        private int _defaultSize = 5;
        private int _countItems = 0;
        public MyStack()
        {
            _stack = new T[_defaultSize];
        }

        public delegate void StackHandler(string message);
        public event StackHandler Notify;

        public void Push(T item)
        {          
            if (_countItems == _defaultSize)
            {
                Resize(item);                
                return;
            }
            _stack[_countItems] = item;
            _countItems++;
            Notify?.Invoke($"В стек добавился элемент: {item}");
        }

        public void Resize(T item)
        {
            _defaultSize = _defaultSize * 2;
            var tempStack = new T[_defaultSize];
            for (var i = 0; i < _countItems; i++)
            {
                tempStack[i] = _stack[i];
            }
            tempStack[_countItems] = item;
            _countItems++;
            Notify?.Invoke($"В стек добавился элемент: {item}");
            _stack = tempStack;
        }

        public T Pop()
        {
            if (_countItems != 0)
            {
                T item = _stack[_countItems - 1];
                _countItems--;
                Notify?.Invoke($"Из стека удален элемент: {item}");
                return item;
            }        
            else
            {
                throw new Exception("Стек пуст");
            }
        }

        public int GetLength()
        {
            return _stack.Length;
        }
    }
}
