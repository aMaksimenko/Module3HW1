using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork
{
    public class MyList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        private T[] _items;
        private int _size;

        public MyList()
        {
            _items = new T[DefaultCapacity];
        }

        public MyList(IEnumerable<T> items)
        {
            var enumerable = items as T[] ?? items.ToArray();

            _items = new T[enumerable.Count()];
            AddRange(enumerable);
        }

        public int Count => _size;

        public int Capacity
        {
            get => _items.Length;
            set
            {
                {
                    var newItems = new T[value];

                    if (_size > 0)
                    {
                        Array.Copy(_items, newItems, _size);
                    }

                    _items = newItems;
                }
            }
        }

        public void Add(T item)
        {
            if (_size >= _items.Length)
            {
                IncreaseCapacity();
            }

            _items[_size] = item;
            _size += 1;
        }

        public void AddRange(IEnumerable<T> items)
        {
            using var en = items.GetEnumerator();

            while (en.MoveNext())
            {
                Add(en.Current);
            }
        }

        public void IncreaseCapacity()
        {
            Capacity = Capacity * 2;
        }

        public bool Remove(T itemToRemove)
        {
            var indexToRemove = Array.IndexOf(_items, itemToRemove, 0, _size);

            if (indexToRemove >= 0)
            {
                RemoveAtIndex(indexToRemove);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveAtIndex(int indexToRemove)
        {
            if (indexToRemove >= 0 && indexToRemove < _size)
            {
                _items[indexToRemove] = default;
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_items, comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _items)
            {
                if (item != null)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}