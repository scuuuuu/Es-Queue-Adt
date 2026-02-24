using System;
using System.Collections.Generic;
using System.Text;

namespace Es_Queue_Adt
{
    internal class CQueue<T> : IQueue<T>
    {
        public CNodo<T>? head;
        public CQueue()
        {
            head = null;
        }

        public void Clear()
        {
            head = null;
        }

        public T Dequeue()
        {
            if(head == null)
            {
                throw new InvalidOperationException("La coda è vuota");
            }
            else
            {
                T value = head.value;
                head = head.Next;
                return value;
            }
        }

        public void Enqueue(T item)
        {
            if(head == null)
            {
                head = new CNodo<T>(item);
            }
            else
            {
                CNodo<T> current = head;
                while(current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = new CNodo<T>(item);
            }
        }

        public bool IsEmpty()
        {
            if(head == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Peek()
        {
            if(head == null)
            {
                throw new InvalidOperationException("La coda è vuota");
            }
            return head.value;
        }
    }
}
