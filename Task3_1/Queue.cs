using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    internal class Queue<T> : IQueue<T>
    {
        private int _head;
        private int _tail;
        private int _maximumCapacity;
        private T[] _queue;

        public int MaximumCapacity
        {
            get
            {
                return _maximumCapacity;
            }
        }

        public int Tail
        {
            get
            {
                return _tail;
            }
            private set
            {
                _tail = value;
            }
        }

        public int Head
        {
            get
            {
                return _head;
            }
            private set
            {
                _head = value;
            }
        }

        public Queue(int maximumCapacity)
        {
            _head = 0;
            _tail = 0;
            _maximumCapacity = maximumCapacity;
            _queue = new T[MaximumCapacity];
        }

        public Queue(T[] queue, int tail)
        {
            _queue = queue;
            _maximumCapacity = _queue.Length;
            _tail = tail;
        }

        public object Clone()
        {
            T[] _tempQueue = new T[MaximumCapacity];

            for (int i = 0; i < Tail; i++)
            {
                _tempQueue[i] = _queue[i];
            }

            return new Queue<T>(_tempQueue, Tail);
        }

        public void Dequeue()
        {
            if (Head == Tail)
            {
                throw new Exception("Cannot dequeue from an empty queue");
            }

            for (int i = 0; i < Tail - 1; i++)
            {
                _queue[i] = _queue[i + 1];
            }

            Tail--;
        }

        public void Enqueue(T item)
        {
            if (Tail == MaximumCapacity)
            {
                throw new Exception("Queue has reached its maximum capacity");
            }

            _queue[Tail] = item;

            Tail++;
        }

        public bool IsEmpty()
        {
            if (_queue == null || Tail == 0)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string output = "[";

            for (int i = 0; i < Tail; i++)
            {
                output += _queue[i] + ",";
            }

            output += "]\n";
            return output;
        }
    }
}
