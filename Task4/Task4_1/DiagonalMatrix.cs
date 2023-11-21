using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    internal class DiagonalMatrix<T>
    {
        private T[] _elementsLocatedOnDiagonal;
        private int _size;

        public delegate void EventHandler(object sender, ElementChangedEventArgs<T> e);

        public delegate T DelegateMethods(T a, T b);

        public event EventHandler ElementChanged;

        public int Size
        {
            get
            {
                return _size;
            }
            private set
            {
                _size = value;
            }
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= _elementsLocatedOnDiagonal.Length || j < 0 || j >= _elementsLocatedOnDiagonal.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (i != j)
                {
                    return default(T);
                }

                return _elementsLocatedOnDiagonal[i];
            }
            set
            {
                if (i == j && i >= 0 && i < _elementsLocatedOnDiagonal.Length)
                {
                    if (!_elementsLocatedOnDiagonal[i].Equals(value))
                    {
                        OnElementChanged(new ElementChangedEventArgs<T>(_elementsLocatedOnDiagonal[i], value, i));
                        _elementsLocatedOnDiagonal[i] = value;
                    }
                    else
                    {
                        _elementsLocatedOnDiagonal[i] = value;
                    }
                }
            }
        }

        public DiagonalMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException();
            }

            Size = size;

            this._elementsLocatedOnDiagonal = new T[Size];
        }

        public DiagonalMatrix(T[] elementsLocatedOnDiagonal)
        {
            Size = elementsLocatedOnDiagonal.Length;

            this._elementsLocatedOnDiagonal = new T[Size];

            for (int i = 0; i < elementsLocatedOnDiagonal.Length; i++)
            {
                this._elementsLocatedOnDiagonal[i] = elementsLocatedOnDiagonal[i];
            }
        }

        protected virtual void OnElementChanged(ElementChangedEventArgs<T> e)
        {
            ElementChanged?.Invoke(this, e);
        }


        static T SumMatrix(T a, T b)
        {
            dynamic number = a;
            dynamic number2 = b;
            return number + number2;
        }
    }
}
