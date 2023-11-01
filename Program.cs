using System;

namespace Task1
{
    internal class Program
    {
        static void DisplayArray(int size, int[] array)
        {
            for (int i = 0; i < size; i++)
            {
                if (i < (size - 1))
                {
                    Console.Write($"{array[i]},");
                }
                else
                {
                    Console.Write($"{array[i]}]\n");
                }
            }
        }

        static bool ConvertToDuodecimal(int decimalNumber)
        {
            string duodecimal = "";
            char duodecimalDigit;

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

                if(duodecimal.Contains("AA"))
                {
                    return true;
                }

                decimalNumber /= 12;
            }

            return false;
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

            if(numberB >= 130)
            {
                Console.WriteLine("Numbers which in their duodecimal representation have exactly two symbols A are:");

                for (int i = numberA; i <= numberB; i++)
                {
                    if (ConvertToDuodecimal(i))
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
            string formattedCheckDigit;

            if (checkDigit == 10)
            {
                formattedCheckDigit = "X";
            }
            else
            {
                formattedCheckDigit = checkDigit.ToString();
            }

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

            DisplayArray(numberElements, originalArray);

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
                    tempArray[uniqueCount] = originalArray[i];
                    uniqueCount++;
                }
            }

            int[] finalArray = new int[uniqueCount];

            for (int i = 0; i < uniqueCount; i++)
            {
                finalArray[i] = tempArray[i];
            }

            Console.WriteLine("Only Once Array:");
            Console.Write("[");

            DisplayArray(uniqueCount, finalArray);
        }
    }
}