using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal static class ExtensionMethods
    {
        public static DiagonalMatrix SumDiagonalMatrixs(this DiagonalMatrix diagonalMatrix, DiagonalMatrix diagonalMatrix2)
        {
            int[] result;
            result = diagonalMatrix2.Size > diagonalMatrix.Size ? new int[diagonalMatrix2.Size] : new int[diagonalMatrix.Size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = diagonalMatrix[i, i] + diagonalMatrix2[i, i];
            }

            return new DiagonalMatrix(result);
        }
    }
}
