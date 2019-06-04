using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public interface IBaseRepository<T> where T : class
    {
        T Find(int id);
        void Add(T item);
        void Remove(T item);
        void Edit(T item);
    }
}
