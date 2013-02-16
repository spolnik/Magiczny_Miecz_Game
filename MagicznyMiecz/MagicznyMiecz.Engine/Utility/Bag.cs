using System.Collections;
using System.Collections.Generic;
using MagicznyMiecz.Common.Utility;

namespace MagicznyMiecz.Engine.Utility
{
    internal class Bag<T> : IBag<T>
    {
        internal static Bag<T> Create()
        {
            return new Bag<T>();
        }

        private readonly List<T> _items;

        private Bag()
        {
            this._items = new List<T>();
        }

        #region IBag<T> Members

        public int Count
        {
            get { return this._items.Count; }
        }

        public T this[int index]
        {
            get { return this._items[index]; }
        }

        public bool Remove(T item)
        {
            return this._items.Remove(item);
        }

        public void Add(T item)
        {
            this._items.Add(item);
        }

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
