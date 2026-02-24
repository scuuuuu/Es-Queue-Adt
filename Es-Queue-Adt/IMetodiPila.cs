using System;
using System.Collections.Generic;
using System.Text;

namespace Es_pila
{
    internal interface IMetodiPila<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        void Clear();
        bool IsEmpty();
    }
}
