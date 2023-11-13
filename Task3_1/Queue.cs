using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1
{
    internal class Queue<T> : IQueue<T>
    {
        private int _size;
        private int _maximumCapacity;
        private T[] _queue;

        public Queue()
        {
            _size = 0;
            _queue = new T[_size];
            //The maximum capacity its 32 by default for testing purposes only 
            _maximumCapacity = 32;
        }

        public Queue(int maximumCapacity)
        {
            _size = 0;
            _queue = new T[_size];
            _maximumCapacity = maximumCapacity;
        }

        public Queue(T[] queue)
        {
            _queue = queue;
            _size = _queue.Length;
            _maximumCapacity = 32;
        }

        public object Clone()
        {
            T[] _tempQueue = new T[_queue.Length];

            for (int i = 0; i < _queue.Length; i++)
            {
                _tempQueue[i] = _queue[i];
            }

            return new Queue<T>(_tempQueue);
        }

        public void Dequeue()
        {
            if( _queue.Length == 0 )
            {
                throw new Exception("Cannot dequeue from an empty queue");
            }

            T[] _tempQueue = new T[--_size];
            for(int i = 0; i < _queue.Length - 1; i++)
            {
                _tempQueue[i] = _queue[i + 1];
            }

            _queue = _tempQueue;
        }

        public void Enqueue(T item)
        {
            if (_queue.Length + 1 > _maximumCapacity)
            {
                throw new Exception("Queue has reached its maximum capacity");
            }

            T[] _tempQueue = new T[++_size];

            for(int i = 0; i < _queue.Length; i++)
            {
                _tempQueue[i] = _queue[i];
            }

            _tempQueue[_tempQueue.Length - 1] = item;

            _queue = _tempQueue;
        }

        public bool IsEmpty()
        {
            if(_queue == null || _size == 0)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            string output = "[";

            foreach (T item in _queue)
            {
                output += item.ToString() + ",";
            }

            output += "]\n";
            return output;
        }
    }
}
