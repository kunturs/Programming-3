using System;
using System.Collections.Generic;

namespace Lab_10
{
    public static class Functions
    {
        public static Func<double, double> Constant (double constantValue)
        {
            return (x) => constantValue;
        }

        public static Func<double, double> Identity()
        {
            return (x) => x;
        }

        public static Func<double, double> Exp(double coefficientValue)
        {
            return (x) => Math.Exp(x) * coefficientValue;
        }
    }

    public class Function
    {
        

        private Func<double, double> internalFunction;

        public Function(Func<double, double> fp)
        {
            func = fp;
        }

        private Func<double, double> func {

            get => internalFunction;
            set { internalFunction += value; }
        }
        public double Value(double d)
        {
            return internalFunction(d);
        }

        public static implicit operator Function(Func<double, double> f)
        {
            return new Function(f);
        }

        public IEnumerable<double> GetValues(double aValue, double bValue, int nValue)
        {
            for(int i=0; i<nValue; i++)
            {
                yield return internalFunction(aValue + (bValue - aValue) / nValue * i);
            }
        }
    }

    //public class Polynomial : Function
    //{
    //    static ToFunction(double[] coefficientValues)
    //    {

    //    }
    //}

    public static class NumericalMethod 
    {
        public static double Derivative (this Function f, double x)
        {
            double h = 0.001;
            return (f.Value(x+h) - f.Value(x -h))/ (2 * h);
        }


        public static double Integral(this Function f, double x)
        {
            double n = 100;
            //Func<double, double> f1 = Functions.Exp(1);
            return (f.Value(x) - f.Value(x +1)) / (2 * n);
        }

        //public static Func<double, double> Integral(this double h)
        //{
        //    return (x) => ((x) + (x + 1)) / 2 * h;
        //    /*Sum of (F(xi) + F(xi+1)) / 2 * h'.*/
        //}

    }


   

}