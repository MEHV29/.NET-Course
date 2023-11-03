using System;

namespace Task1
{
    internal class Program
    {
        static void DisplayArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]},");
            }

            Console.Write("]\n");
        }

        static bool ValidateNumberContainsExactlyAA(int decimalNumber)
        {
            string duodecimal = "";
            char duodecimalDigit;
            int counterAA = 0;

            if(decimalNumber < 0)
            {
                decimalNumber = -decimalNumber;
            }

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % 12;

                if(remainder < 10)
                {
                    duodecimalDigit = (char)(remainder + '0');
                }
                else
                {
                    duodecimalDigit = (char)(remainder - 10 + 'A');
                }

                duodecimal = duodecimalDigit + duodecimal;

                decimalNumber /= 12;
            }

            for(int i = 0; i<duodecimal.Length; i++)
            {
                if (duodecimal[i] == 'A')
                {
                    counterAA++;
                }
            }

            return counterAA == 2;
        }

        static void Main(string[] args)
        {
            //Task 1.1
            Console.WriteLine("Please enter number a:");
            string inputA = Console.ReadLine();
            Console.WriteLine("Please enter number b:");
            string inputB = Console.ReadLine();

            int numberA = int.Parse(inputA);
            int numberB = int.Parse(inputB);

            if(numberB < numberA)
            {
                int temp = numberA;
                numberA = numberB;
                numberB = temp;
            }

            // 130 && -130 are the numbers closest to 0 that contains exactly two AA symbols in its duodecimal representation.
            if (numberB >= 130 || numberA <= -130)
            {
                Console.WriteLine("Numbers which in their duodecimal representation have exactly two symbols A are:");

                for (int i = numberA; i <= numberB; i++)
                {
                    if (ValidateNumberContainsExactlyAA(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("None integer on the range have exactly two symbols A");
            }
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Task 1.2
            Console.WriteLine("Please enter the first nine digits of the ISBN:");
            string isbn = Console.ReadLine();

            int weightPosition = 10;
            int sumProducts = 0;

            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(isbn[i].ToString());

                sumProducts += digit * weightPosition;

                weightPosition--;
            }

            int checkDigit = 11 - (sumProducts % 11);
            string formattedCheckDigit = checkDigit == 10 ? "X" : checkDigit.ToString(); ;

            isbn = string.Format("{0}-{1}-{2}-{3}",
            isbn[0],
            isbn.Substring(1, 4),
            isbn.Substring(5, 4),
            formattedCheckDigit);

            Console.WriteLine($"The ISBN is: {isbn}");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            //Task 1.3
            Console.WriteLine("Please enter number of elements in the array:");
            string input = Console.ReadLine();
            int numberElements = int.Parse(input);
            int[] originalArray = new int[numberElements];
            int[] tempArray = new int[numberElements];
            
            int uniqueCount = 1;

            for (int i = 0; i < numberElements; i++)
            {
                Console.WriteLine($"Please enter value of the element {i}");
                string value = Console.ReadLine();
                originalArray[i] = int.Parse(value);
                Console.Clear();
            }

            Console.WriteLine("Original Array:");
            Console.Write("[");

            DisplayArray(originalArray);

            tempArray[0] = originalArray[0];

            for (int i = 1; i < numberElements; i++)
            {
                bool isDuplicate = false;
                for (int j = 0; j < uniqueCount; j++)
                {
                    if (originalArray[i] == tempArray[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (!isDuplicate)
                {
                    tempArray[uniqueCount++] = originalArray[i];
                }
            }

            int[] finalArray = new int[uniqueCount];

            for (int i = 0; i < uniqueCount; i++)
            {
                finalArray[i] = tempArray[i];
            }

            Console.WriteLine("Only Once Array:");
            Console.Write("[");

            DisplayArray(finalArray);
        }
    }
}