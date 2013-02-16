using System.Collections.Generic;

namespace MagicznyMiecz.Common.Utility
{
    public interface IBag<T> : IEnumerable<T>
    {
        int Count { get; }
        T this[int index] { get; }
        bool Remove(T item);
        void Add(T item);
    }
}