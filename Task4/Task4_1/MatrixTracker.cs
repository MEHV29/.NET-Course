using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1
{
    internal class MatrixTracker<T>
    {
        DiagonalMatrix<T> _diagonalMatrix;

        private T _oldValue;
        private T _newValue;
        private int _index;

        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            _diagonalMatrix = matrix;
            matrix.ElementChanged += ElementHasChanged;
        }

        void ElementHasChanged(object sender, ElementChangedEventArgs<T> e)
        {
            _newValue = e.NewValue;
            _oldValue = e.OldValue;
            _index = e.Index;
        }

        public void Undo()
        {
            _diagonalMatrix[_index, _index] = _oldValue;
        }
    }
}
