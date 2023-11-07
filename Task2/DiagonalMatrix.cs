using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task2
{
    internal class DiagonalMatrix
    {
        private int[] elementsLocatedOnDiagonal;
        private int size;
        public int Size
        {
            get
            {
                return size;
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
                else if (i < 0 || i >= elementsLocatedOnDiagonal.Length)
                {
                    return 0;
                }

                return elementsLocatedOnDiagonal[i];
            }
            set
            {
                if (i == j && i >= 0 && i < elementsLocatedOnDiagonal.Length)
                {
                    elementsLocatedOnDiagonal[i] = value;
                }
            }
        }

        public DiagonalMatrix(params int[] elementsLocatedOnDiagonal)
        {
            if (elementsLocatedOnDiagonal == null || elementsLocatedOnDiagonal.Length == 0)
            {
                size = 0;
                this.elementsLocatedOnDiagonal = new int[size];
            }
            else
            {
                size = elementsLocatedOnDiagonal.Length;
                this.elementsLocatedOnDiagonal = new int[size];
                for (int i = 0; i < elementsLocatedOnDiagonal.Length; i++)
                {
                    this.elementsLocatedOnDiagonal[i] = elementsLocatedOnDiagonal[i];
                }
            }
        }

        public int Track()
        {
            int sum = 0;

            foreach (int i in elementsLocatedOnDiagonal)
            {
                sum += i;
            }

            return sum;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (obj is not DiagonalMatrix) return false;

            if (this.size != ((DiagonalMatrix)obj).Size) return false;

            for (int i = 0; i < elementsLocatedOnDiagonal.Length; i++)
            {
                if (this.elementsLocatedOnDiagonal[i] != ((DiagonalMatrix)obj)[i, i]) return false;
            }

            return true;
        }

        public override string ToString()
        {
            string output = "[";
            for (int i = 0; i < elementsLocatedOnDiagonal.Length; i++)
            {
                for (int j = 0; j < elementsLocatedOnDiagonal.Length; j++)
                {
                    output += this[i,j];
                    if (j < elementsLocatedOnDiagonal.Length - 1) output += ",";
                }
                output += "]\n";
                if (i < elementsLocatedOnDiagonal.Length - 1) output += "[";
            }
            /* Only display elements on the Diagonal
            foreach (int i in elementsLocatedOnDiagonal)
            {
                output += i + ",";
            }
            output += "]";
            */
            if(size == 0) output += "]";

            return output;
        }

        public DiagonalMatrix Extension(DiagonalMatrix diagonalMatrix)
        {
            int[] result; 
            if (diagonalMatrix.Size < this.size) result = new int[size];
            else if(diagonalMatrix.Size > this.size) result = new int[diagonalMatrix.Size];
            else result = new int[size];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = elementsLocatedOnDiagonal[i] + diagonalMatrix[i, i];
            }

            return new DiagonalMatrix(result);
        }
    }
}
