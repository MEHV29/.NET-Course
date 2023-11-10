using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task2
{
    internal class DiagonalMatrix
    {
        private int[] _elementsLocatedOnDiagonal;
        private int _size;
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

        public int this[int i, int j]
        {
            get
            {
                if (i != j)
                {
                    return 0;
                }
                else if (i < 0 || i >= _elementsLocatedOnDiagonal.Length)
                {
                    return 0;
                }

                return _elementsLocatedOnDiagonal[i];
            }
            set
            {
                if (i == j && i >= 0 && i < _elementsLocatedOnDiagonal.Length)
                {
                    _elementsLocatedOnDiagonal[i] = value;
                }
            }
        }

        public DiagonalMatrix(params int[] elementsLocatedOnDiagonal)
        {
            Size = elementsLocatedOnDiagonal == null ? 0 : elementsLocatedOnDiagonal.Length;

            this._elementsLocatedOnDiagonal = new int[Size];

            for (int i = 0; i < elementsLocatedOnDiagonal.Length; i++)
            {
                this._elementsLocatedOnDiagonal[i] = elementsLocatedOnDiagonal[i];
            }
        }

        public int Track()
        {
            int sum = 0;

            foreach (int i in _elementsLocatedOnDiagonal)
            {
                sum += i;
            }

            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj is not DiagonalMatrix || this.Size != ((DiagonalMatrix)obj).Size)
            {
                return false;
            }

            for (int i = 0; i < _elementsLocatedOnDiagonal.Length; i++)
            {
                if (this._elementsLocatedOnDiagonal[i] != ((DiagonalMatrix)obj)[i, i])
                {
                    return false;
                }
            }

            return true;
        }

        public override string ToString()
        {
            string output = "[";
            for (int i = 0; i < _elementsLocatedOnDiagonal.Length; i++)
            {
                for (int j = 0; j < _elementsLocatedOnDiagonal.Length; j++)
                {
                    output += this[i, j];
                    if (j < _elementsLocatedOnDiagonal.Length - 1)
                    {
                        output += ",";
                    }
                }
                output += "]\n";
                if (i < _elementsLocatedOnDiagonal.Length - 1)
                {
                    output += "[";
                }
            }
            /* Only display elements on the Diagonal
            foreach (int i in elementsLocatedOnDiagonal)
            {
                output += i + ",";
            }
            output += "]";
            */
            if (Size == 0)
            {
                output += "]";
            }

            return output;
        }
    }
}
