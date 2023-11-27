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

        void ElementHasChanged(object sender, EventArgs e)
        {
            if(e is ElementChangedEventArgs<T> elementChangedEventArgs)
            {
                _newValue = elementChangedEventArgs.NewValue;
                _oldValue = elementChangedEventArgs.OldValue;
                _index = elementChangedEventArgs.Index;
            }
        }

        public void Undo()
        {
            _diagonalMatrix[_index, _index] = _oldValue;
        }
    }
}
