using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Queue_Adt
{
    internal interface IQueue<T>
    {
        public bool IsEmpty();  
        public void Enqueue(T item);
        public T Dequeue();
        public T Peek();
        public void Clear();    
    }
}
