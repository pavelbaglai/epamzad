using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework_10.Task4
{
    public class QueueT<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _head;
        private int _tail;
        private int _size;
        private const int _MinimumGrow = 4;
        private const int _GrowFactor = 200;  // double each time
        public QueueT()
        {
            _items = new T[0];
            _head = 0;
            _tail = 0;
            _size = 0;
        }


        public void Enqueue(T item)
        {
            if (_tail == _items.Length)
            {
                int newcapacity = (int)((long)_items.Length * (long)_GrowFactor / 100);
                if (newcapacity < _items.Length + _MinimumGrow)
                {
                    newcapacity = _items.Length + _MinimumGrow;
                }
                SetCapacity(newcapacity);
            }
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _size++;
        }
        public T Dequeue()
        {
            if (_size == 0)
                throw new InvalidOperationException();

            T s = _items[_head];
            _items[_head] = default(T);
            _head = (_head + 1) % _items.Length;
            _size--;
            return s;

        }
        public T Peek()
        {
            if (_head == _tail)
            {
                throw new InvalidOperationException();
            }

            return _items[_head];
        }

        public T GetElement(int i)
        {
            return _items[(_head + i) % _items.Length];
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {
            private QueueT<T> _queueT;
            private int _index;   // -1 = not started, -2 = ended/disposed
            private T _currentElement;

            public Enumerator(QueueT<T> queueT)
            {
                _queueT = queueT;
                _index = -1;
                _currentElement = default(T);
            }

            public void Dispose()
            {
                _index = -2;
                _currentElement = default(T);
            }

            public bool MoveNext()
            {

                if (_index == -2)
                    return false;

                _index++;

                if (_index == _queueT._size)
                {
                    _index = -2;
                    _currentElement = default(T);
                    return false;
                }

                _currentElement = _queueT.GetElement(2);
                return true;
            }

            public T Current
            {
                get
                {
                    if (_index < 0)
                    {
                        if (_index == -1)
                            throw new ArgumentOutOfRangeException();
                        else
                            throw new ArgumentOutOfRangeException();
                    }
                    return _currentElement;
                }
            }

            Object System.Collections.IEnumerator.Current
            {
                get
                {
                    if (_index < 0)
                    {
                        if (_index == -1)
                            throw new ArgumentOutOfRangeException();
                        else
                            throw new ArgumentOutOfRangeException();
                    }
                    return _currentElement;
                }
            }

            void System.Collections.IEnumerator.Reset()
            {
                _index = -1;
                _currentElement = default(T);
            }
        }
        private void SetCapacity(int capacity)
        {
            T[] newarray = new T[capacity];
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_items, _head, newarray, 0, _size);
                }
                else
                {
                    Array.Copy(_items, _head, newarray, 0, _items.Length - _head);
                    Array.Copy(_items, 0, newarray, _items.Length - _head, _tail);
                }
            }

            _items = newarray;
            _head = 0;
            _tail = (_size == capacity) ? 0 : _size;
        }
    }
}