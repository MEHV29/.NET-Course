using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    internal class ElementChangedEventArgs<T>
    {
        public T OldValue { get; }
        public T NewValue { get; }
        public int Index { get; }

        public ElementChangedEventArgs(T oldValue, T newValue, int index)
        {
            OldValue = oldValue;
            NewValue = newValue;
            Index = index;
        }
    }
}
