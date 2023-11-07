namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task 2.1
            Point point = new Point();
            point.Mass = -1;
            point.X = 0; 
            point.Y = 0;
            point.Z = 0;
            Console.WriteLine($"Point mass is {point.Mass}");
            Console.WriteLine($"Point is located on (0,0,0): {point.IsZero()}");

            Point point2 = new Point();
            point2.Mass = -1;
            point2.X = 2;
            point2.Y = 3;
            point2.Z = 1;

            Point point3 = new Point();
            point3.Mass = -1;
            point3.X = 8;
            point3.Y = -5;
            point3.Z = 0;

            Console.WriteLine($"Distance between point2 and point3 is {point2.DistanceBetweenPoints(point3)}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Task 2.2
            DiagonalMatrix diagonalMatrix = new DiagonalMatrix();
            diagonalMatrix[0, 0] = 1;
            Console.WriteLine($"{diagonalMatrix.ToString()}");
            Console.WriteLine($"Value on [0,0] is {diagonalMatrix[0, 0]}");
            Console.WriteLine($"Sum of matrix elements is: {diagonalMatrix.Track()}\n");
            Console.WriteLine($"Size of matrix is: {diagonalMatrix.Size}\n");

            DiagonalMatrix diagonalMatrix2 = new DiagonalMatrix(1,2,3,4,5);
            diagonalMatrix2[0, 0] = 5;
            Console.WriteLine($"{diagonalMatrix2.ToString()}");
            Console.WriteLine($"Value on [0,0] is: {diagonalMatrix2[0, 0]}");
            Console.WriteLine($"Sum of matrix elements is: {diagonalMatrix2.Track()}\n");
            Console.WriteLine($"Size of matrix is: {diagonalMatrix2.Size}\n");

            DiagonalMatrix diagonalMatrix3 = new DiagonalMatrix(1, 2, 3, 4, 5);
            Console.WriteLine($"Sum of matrix elements is: {diagonalMatrix3.Track()}");
            Console.WriteLine($"{diagonalMatrix3.ToString()}");
            Console.WriteLine($"Are equals? {diagonalMatrix3.Equals(diagonalMatrix2)}");
            diagonalMatrix3[0, 0] = 5;
            Console.WriteLine($"Sum of matrix elements is: {diagonalMatrix3.Track()}");
            Console.WriteLine($"{diagonalMatrix3.ToString()}");
            Console.WriteLine($"Are equals? {diagonalMatrix3.Equals(diagonalMatrix2)}");
            

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Task 2.3
            Training training = new Training("Training Description");
            Lecture lecture = new Lecture("Lecture Description", "Lecture Topic");
            PracticalLesson practicalLesson = new PracticalLesson("Practical Lesson Description", "Link To Task Condition", "Link To Solution");
            PracticalLesson practicalLesson2 = new PracticalLesson("Practical Lesson Description2", "Link To Task Condition2", "Link To Solution2");
            training.Add(practicalLesson);
            training.Add(practicalLesson2);
            Console.WriteLine($"Is Practical? {training.IsPractical()}");
            Training training2 = training.Clone();
            training2.Add(lecture);
            Console.WriteLine($"Is Practical? {training2.IsPractical()}");
        }
    }
}