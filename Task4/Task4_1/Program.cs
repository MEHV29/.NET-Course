namespace Task4_1
{
    internal class Program
    {
        public delegate T SumDelegate<T>(T a, T b);

        static void Main(string[] args)
        {
            DiagonalMatrix<int> diagonalMatrix = new DiagonalMatrix<int>(5);
            MatrixTracker<int> matrixTracker = new MatrixTracker<int>(diagonalMatrix);
            diagonalMatrix[0, 0] = 0;
            diagonalMatrix[1, 1] = 1;
            diagonalMatrix[2, 2] = 2;
            diagonalMatrix[3, 3] = 3;
            diagonalMatrix[4, 4] = 4;
            matrixTracker.Undo();
            matrixTracker.Undo();
            DiagonalMatrix<int> diagonalMatrix2 = new DiagonalMatrix<int>(5);
            diagonalMatrix2[0, 0] = 5;
            diagonalMatrix2[1, 1] = 6;
            diagonalMatrix2[2, 2] = 7;
            diagonalMatrix2[3, 3] = 8;
            diagonalMatrix2[4, 4] = 9;
            Func<int, int, int> add = Sum;
            DiagonalMatrix<int> resultDiagonalMatrix = diagonalMatrix.SumDiagonalMatrixs(diagonalMatrix2, add);
        }

        static T Sum<T>(T a, T b)
        {
            dynamic dynamicA = a;
            dynamic dynamicB = b;
            return  dynamicA + dynamicB;
        }
    }
}