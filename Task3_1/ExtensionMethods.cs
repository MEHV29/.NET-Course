using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    internal static class ExtensionMethods
    {
        public static Queue<T> Tail<T>(this IQueue<T> queue)
        {
            Queue<T> tail = (Queue<T>)queue.Clone();
            tail.Dequeue();
            return tail;
        }
    }
}
