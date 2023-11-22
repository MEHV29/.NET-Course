namespace Task4_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RationalNumber rationalNumber = new RationalNumber(6, 8);
            RationalNumber rationalNumber2 = new RationalNumber(4, 11);
            RationalNumber rationalNumber3 = new RationalNumber(2, 6);
            Console.WriteLine(rationalNumber.ToString());
            Console.WriteLine($"Are Equals: {rationalNumber.Equals(rationalNumber2)}");
            Console.WriteLine($"Are Equals: {rationalNumber.Equals(1)}\n");

            List<RationalNumber> list = new List<RationalNumber>();
            list.Add(rationalNumber);
            list.Add(rationalNumber2);
            list.Add(rationalNumber3);
            list.Sort();
            Console.WriteLine("Order by value DESC:");
            foreach (RationalNumber number in list)
            {
                Console.WriteLine(number.ToString());
            }

            RationalNumber rationalNumberAdd = new RationalNumber(2, 3);
            RationalNumber rationalNumberAdd2 = new RationalNumber(4, 5);
            RationalNumber resultAdd = rationalNumberAdd + rationalNumberAdd2;
            Console.WriteLine($"\nResult of add: {resultAdd.ToString()}");

            RationalNumber rationalNumberSubstract = new RationalNumber(5, 6);
            RationalNumber rationalNumberSubstract2 = new RationalNumber(3, 10);
            RationalNumber resultSubstract = rationalNumberSubstract - rationalNumberSubstract2;
            Console.WriteLine($"\nResult of substract: {resultSubstract.ToString()}");

            RationalNumber rationalNumberMultiply = new RationalNumber(5, 6);
            RationalNumber rationalNumberMultiply2 = new RationalNumber(4, 3);
            RationalNumber resultMultiply = rationalNumberMultiply * rationalNumberMultiply2;
            Console.WriteLine($"\nResult of multiply: {resultMultiply.ToString()}");

            RationalNumber rationalNumberDivide = new RationalNumber(5, 6);
            RationalNumber rationalNumberDivide2 = new RationalNumber(4, 3);
            RationalNumber resultDivide = rationalNumberDivide / rationalNumberDivide2;
            Console.WriteLine($"\nResult of divide: {resultDivide.ToString()}");

            double rationalToDouble = (double)resultDivide;
            Console.WriteLine($"\nRational to Double: {rationalToDouble.ToString()}");

            RationalNumber intToRational = (RationalNumber)10;
            Console.WriteLine($"\nInt to Rational: {intToRational.ToString()}");
        }
    }
}