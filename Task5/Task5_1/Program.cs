namespace Task5_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SparseMatrix sparseMatrix = new SparseMatrix(5, 5);
            sparseMatrix[0, 0] = 1;
            sparseMatrix[0, 1] = 8;
            sparseMatrix[1, 0] = 9;
            sparseMatrix[1, 1] = 2;
            sparseMatrix[2, 2] = 3;
            sparseMatrix[3, 3] = 9;
            sparseMatrix[4, 4] = 9;
            Console.WriteLine(sparseMatrix.ToString());

            Console.WriteLine("\nElements order by row");
            foreach (var value in sparseMatrix)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine("\nNon-null elements order by column");

            foreach (var value in sparseMatrix.GetNonzeroElements())
            {
                Console.WriteLine(value);
            }

            Console.WriteLine($"\nCount: {sparseMatrix.GetCount(0)}");
        }
    }
}