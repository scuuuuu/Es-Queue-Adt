using Es_Queue_Adt;
using System;
using System.Collections.Generic;
using System.Text;

namespace Es_pila
{
    internal class CPila<T> : IMetodiPila<T>
    {
         private CNodo<T>? sopra;
         public CPila()
         {
            sopra = null;
         }
         public void Push(T value)
         {
            CNodo<T>? newNode = new CNodo<T>(value);
            if(sopra == null)
            {
                sopra = newNode;
                return;
            }
            newNode.Next = sopra;
            sopra = newNode;
        }
        public T Pop()
        {
            if(sopra == null)
            {
                throw new Exception("La pila è vuota");
            }
            T value = sopra.value;
            sopra = sopra.Next;
            return value;
        }
        public T? Peek()
        {
            if(sopra == null)
            {
                throw new Exception("La pila è vuota");
            }
            return sopra.value;
        }
        public void Clear()
        {
           sopra = null;
        }
        public bool IsEmpty()
        {
            if(sopra == null)
            {
                return true;
            }
            return false;
        }
    }
}