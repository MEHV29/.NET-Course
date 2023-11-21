using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task4_1.Program;

namespace Task4_1
{
    internal static class ExtensionMethods
    {
        public static DiagonalMatrix<T> SumDiagonalMatrixs<T>(this DiagonalMatrix<T> diagonalMatrix, DiagonalMatrix<T> diagonalMatrix2, SumDelegate<T> sumDelegate)
        {
            T[] result;
            result = diagonalMatrix2.Size > diagonalMatrix.Size ? new T[diagonalMatrix2.Size] : new T[diagonalMatrix.Size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = sumDelegate(diagonalMatrix[i, i], diagonalMatrix2[i, i]);
            }

            return new DiagonalMatrix<T>(result);
        }
    }
}
