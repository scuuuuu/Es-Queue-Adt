using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Queue_Adt
{
    internal class CNodo<T>
    {
        public T value;
        public CNodo<T>? Next { get; set; }   
        public CNodo(T value)
        {
            this.value = value;
            this.Next = null;
        }
    }
}
