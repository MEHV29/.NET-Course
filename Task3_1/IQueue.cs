using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    internal interface IQueue<T> : ICloneable
    {
        void Enqueue(T item);

        void Dequeue();

        bool IsEmpty();
    }
}
