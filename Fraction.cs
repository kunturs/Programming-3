using System;
using System.Globalization;
namespace Fraction
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public long Numerator { get => numerator; set
            {
                numerator = value;
                simplify();
            }
        }
        public long Denominator { get => denominator;
            set
            {
                if (denominator == 0)
                    value = 1;
                denominator = value;

                simplify();

            }

        }

        // TODO: Implement properties and constructor

        public Fraction (long n, long d)
        {
            numerator = n;
            denominator = d;

            simplify();
        }

        public Fraction(long n)
        {
            numerator = n;
            denominator = 1;

        }

        public void simplify()
        {
            var g = Gcd(numerator, denominator);
            numerator /= g;
            denominator /= g;
        }


        public static long Gcd(long numerator, long denominator)
        {

            if (denominator == 0)
                return numerator;
            else
                return Gcd(denominator, numerator % denominator);

        }

        public Fraction Reciprocal()
        {
            return new Fraction(denominator, numerator);
        }

   

        public override string ToString()
        {
            var whole = numerator / denominator;
            var num = numerator - whole * denominator;
            var sign = numerator > 0;

            var str = string.Empty;
            if (!sign)
            {
                str += "-";
                num = -num;
                whole = -whole;
            }
            if (num == 0)
                str += $"[{whole}]";
            else if (whole != 0)
                str += $"[{whole} {num}/{denominator}]";
            else
                str += $"[{num}/{denominator}]";

            return str;
        }

        public static implicit operator Fraction(long number)
        {
            return new Fraction(number, 1);
        }

        public static explicit operator long(Fraction fraction)
        {
            return (long)(long)fraction;
        }

        public static explicit operator double(Fraction fraction)
        {
            return (double)(fraction.numerator/fraction.denominator);
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            Fraction f = new Fraction(fraction1.numerator + fraction2.numerator, fraction1.denominator + fraction2.denominator);
            f.simplify();
            return f;
        }


        public static Fraction operator -(Fraction fraction1)
        {
            return new Fraction(-fraction1.numerator, -fraction1.denominator);
        }




        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            Fraction f = new Fraction(fraction1.numerator - fraction2.numerator, fraction1.denominator - fraction2.denominator);
            f.simplify();
            return f;
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {

            Fraction f = new Fraction(fraction1.numerator / fraction2.numerator, fraction1.denominator / fraction2.denominator);
            f.simplify();
            return f;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {

            Fraction f = new Fraction(fraction1.numerator * fraction2.numerator, fraction1.denominator * fraction2.denominator);
            f.simplify();
            return f;

        }

  

        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.Equals(fraction2);
        }

        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !fraction1.Equals(fraction2);
        }

        public static bool operator < (Fraction f1, Fraction f2)
        {
            return f1.numerator * f2.denominator < f2.denominator*f2.numerator;
        }





        //  public static bool operator >(Fraction fraction1, Fraction fraction2)
        //{
        //   if(fraction1.denominator == fraction2.denominator)
        //    {
        //        if(fraction1.numerator > fraction2.numerator)
        //        {
        //            return true;
        //        }
        //    }
        //   else if(fraction1.numerator < fraction2.numerator){
        //        return true;
        //    }
        //    return false;
        //}

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator <=(Fraction fraction1, Fraction fraction2)
        {
            return fr
        }

        public static bool operator >=(Fraction fraction1, Fraction fraction2)
        {
            return fraction1.CompareTo(fraction2) >= 0;
        }
        //public override Fraction Equals(object fraction1)
        //{
        //    return this.Equals((Fraction)fraction1);
        //}

        // TODO: Implement all others methods, operators, etc.
    }
}

/*
 
Your task is to implement Fraction structure.

It should contain two public properties: Numerator and Denominator.
For integers represented as fraction the denominator should be 1.
The denominator should be always positive - sign of the fraction should be placed in the numerator.
ArgumentException should be thrown when denominator is set to 0 or negative number.

The structure has 2 public constructors:
* 2-parameters constructor (long n, long d) 
* 1-parameter constructor (long n). For 1-parameter constructor the denominator is set to 1.

You should implement method to simplify fraction, eg. [2/4] -> [1/2], [3/9] -> [1/3]. 
The helper method to calculate greatest common divisor would be helpful to calculate simplified fraction.
The fraction should be always smplified (also when numerator or denominator changed).

You need to implement Reciprocal() method to invert the fraction, eg. [2/3] -> [3/2] ([1 1/2]). 
Reciprocal method should return simplified fraction too.

You need to implement 3 converters
- implicit from long type to Fraction
- explicit from Fraction to long
- explicit from Fraction to double

You need to implement arithmetic operators + - * / and unary -. Be aware of an overflow during operations on large numbers.
The operators should return simplified fractions.

You need to implement comparison operators == != < > <= >= and override methods related to these operators.

Note! You can't use any floating point types inside Fraction structure (except implementation of conversion to double)

Points:
1.5p - constructors, properties, simplify fraction and Reciprocal() method
1.5p - converters and arithmetic operators
1p - comparison operators and methods related to them
1p - hard tests (operations on large numbers)*/