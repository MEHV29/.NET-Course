namespace Task4_2
{
    internal sealed class RationalNumber : IComparable
    {
        public int Numerator { get; }

        public ushort Denominator { get; }

        public RationalNumber(int numerator, ushort denominator)
        {
            if (denominator == 0)
            {
                throw new Exception();
            }

            int gcd = GetGCD(numerator, denominator);

            Numerator = numerator / gcd;
            Denominator = ((ushort)(denominator / gcd));
        }

        public override bool Equals(object? obj)
        {
            if (obj is not RationalNumber || ((RationalNumber)obj).Denominator != this.Denominator || ((RationalNumber)obj).Numerator != this.Numerator)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            string output = Numerator.ToString() + "/" + Denominator.ToString();
            return output;
        }

        int GetGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        int GetLCM(int a, int b)
        {
            int gcd = GetGCD(a, b);
            return Math.Abs(a * b) / gcd;
        }

        public int CompareTo(object? obj)
        {
            if (obj is RationalNumber other)
            {
                int crossProduct1 = this.Numerator * other.Denominator;
                int crossProduct2 = other.Numerator * this.Denominator;

                return crossProduct2.CompareTo(crossProduct1);
            }
            else
            {
                throw new ArgumentException("Object is not a RationalNumber");
            }
        }

        public static RationalNumber operator +(RationalNumber number, RationalNumber other)
        {
            if(number == null || other == null)
            {
                throw new ArgumentException("Operation cannot be applied for null values");
            }

            if (number.Denominator == other.Denominator)
            {
                var numerator = number.Numerator + other.Numerator;

                return new RationalNumber(numerator, number.Denominator);
            }
            else
            {
                var denominator = number.GetLCM(number.Denominator, other.Denominator);
                var numerator = number.Numerator * other.Denominator;
                var numerator2 = other.Numerator * number.Denominator;

                return new RationalNumber(numerator + numerator2, (ushort)denominator);
            }
        }

        public static RationalNumber operator -(RationalNumber number, RationalNumber other)
        {
            if (number == null || other == null)
            {
                throw new ArgumentException("Operation cannot be applied for null values");
            }

            if (number.Denominator == other.Denominator)
            {
                var numerator = number.Numerator - other.Numerator;

                return new RationalNumber(numerator, number.Denominator);
            }
            else
            {
                var denominator = number.GetLCM(number.Denominator, other.Denominator);
                var numerator = number.Numerator * other.Denominator;
                var numerator2 = other.Numerator * number.Denominator;

                return new RationalNumber(numerator - numerator2, (ushort)denominator);
            }
        }

        public static RationalNumber operator *(RationalNumber number, RationalNumber other)
        {
            if (number == null || other == null)
            {
                throw new ArgumentException("Operation cannot be applied for null values");
            }

            var numerator = number.Numerator * other.Numerator;
            var denominator = number.Denominator * other.Denominator;

            return new RationalNumber(numerator, (byte)denominator);
        }

        public static RationalNumber operator /(RationalNumber number, RationalNumber other)
        {
            if (number == null || other == null)
            {
                throw new ArgumentException("Operation cannot be applied for null values");
            }

            if(other.Numerator == 0)
            {
                throw new ArgumentException("Operation cannot be applied when Numerator from other its 0");
            }

            var numerator = number.Numerator * other.Denominator;
            var denominator = number.Denominator * other.Numerator;

            return new RationalNumber(numerator, (ushort)denominator);
        }

        public static explicit operator double(RationalNumber rational)
        {
            if (rational == null)
            {
                throw new ArgumentException("Casting cannot be applied for null value");
            }

            return (double)rational.Numerator / rational.Denominator;
        }

        public static explicit operator RationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }
    }
}
