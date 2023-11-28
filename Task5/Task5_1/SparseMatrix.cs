using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_1
{
    internal class SparseMatrix : IEnumerable<long>
    {
        private List<(int rowIndex, int colIndex, long value)> _matrixElement;
        private int _numRows;
        private int _numCols;

        public long this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= _numRows || j < 0 || j >= _numCols)
                {
                    throw new IndexOutOfRangeException("Invalid matrix indices");
                }

                return _matrixElement.Find(x => x.rowIndex == i && x.colIndex == j).value;
            }
            set
            {
                if (i < 0 || i >= _numRows || j < 0 || j >= _numCols)
                {
                    throw new IndexOutOfRangeException("Invalid matrix indices");
                }

                _matrixElement.Add((i, j, value));
            }
        }

        public SparseMatrix(int numRows, int numCols)
        {
            if (numRows <= 0 || numCols <= 0)
            {
                throw new ArgumentException("None value can be ZERO or less");
            }

            _numCols = numCols;
            _numRows = numRows;
            _matrixElement = new List<(int rowIndex, int colIndex, long value)>();
        }

        public IEnumerator<long> GetEnumerator()
        {
            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numCols; j++)
                {
                    yield return this[i, j];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            string output = "";

            for (int i = 0; i < _numRows; i++)
            {
                output += "[";

                for (int j = 0; j < _numCols; j++)
                {
                    output += this[i, j] + ",";
                }

                output += "]\n";
            }

            return output;
        }

        public IEnumerable<(int, int, long)> GetNonzeroElements()
        {
            var nonZeroElements = new List<(int index_i, int index_j, long value)>();

            for (int i = 0; i < _numRows; i++)
            {
                for (int j = 0; j < _numCols; j++)
                {
                    if (this[i, j] != 0)
                    {
                        nonZeroElements.Add((i, j, this[i, j]));
                    }
                }
            }

            return nonZeroElements.OrderBy(x => x.index_j);
        }

        public int GetCount(long x)
        {
            if(x == 0)
            {
                return (_numCols * _numRows) - GetNonzeroElements().Count();
            }

            return _matrixElement.FindAll(y => y.value == x).Count();
        }
    }
}
