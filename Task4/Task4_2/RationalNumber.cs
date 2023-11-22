using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_2
{
    internal sealed class RationalNumber : IComparable
    {
        public int Numerator { get; }

        public byte Denominator { get; }

        public RationalNumber(int numerator, byte denominator)
        {
            if (denominator == 0)
            {
                throw new Exception();
            }

            int gcd = GetGCD(numerator, denominator);

            Numerator = numerator / gcd;
            Denominator = (byte)(denominator / gcd);
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
            if (obj is RationalNumber)
            {
                double doubleNumber = (double)(RationalNumber)obj;
                double doubleNumber2 = (double)this;

                if (doubleNumber < doubleNumber2)
                {
                    return -1;
                }
                else if (doubleNumber == doubleNumber2)
                {
                    return 0;
                }

                return 1;
            }
            else
            {
                throw new Exception("Object is not a Rational Number");
            }
        }

        public static RationalNumber operator +(RationalNumber number, RationalNumber other)
        {
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

                return new RationalNumber(numerator + numerator2, (byte)denominator);
            }
        }

        public static RationalNumber operator -(RationalNumber number, RationalNumber other)
        {
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

                return new RationalNumber(numerator - numerator2, (byte)denominator);
            }
        }

        public static RationalNumber operator *(RationalNumber number, RationalNumber other)
        {
            var numerator = number.Numerator * other.Numerator;
            var denominator = number.Denominator * other.Denominator;

            return new RationalNumber(numerator, (byte)denominator);
        }

        public static RationalNumber operator /(RationalNumber number, RationalNumber other)
        {
            var numerator = number.Numerator * other.Denominator;
            var denominator = number.Denominator * other.Numerator;

            return new RationalNumber(numerator, (byte)denominator);
        }

        public static explicit operator double(RationalNumber rational)
        {
            return (double)rational.Numerator / rational.Denominator;
        }

        public static explicit operator RationalNumber(int value)
        {
            return new RationalNumber(value, 1);
        }
    }
}
