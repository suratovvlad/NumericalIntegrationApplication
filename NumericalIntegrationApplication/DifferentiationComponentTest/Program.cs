using System;
using System.Collections.Generic;
using DifferentiationComponent;

namespace DifferentiationComponentTest
{
    class Program
    {
        static private decimal UserFunction(decimal x)
        {
            //return Convert.ToDecimal(Math.Cos(Convert.ToDouble(x)));
            return x * x * x * x;
        }

        static private void FirstTest()
        {
            int n = 5;
            decimal a = -2;
            decimal b = 7;
            decimal h = (b - a) / n;

            List<decimal> Xs = new List<decimal>();
            List<decimal> Ys = new List<decimal>();
            for (int i = 0; i < n; ++i)
            {
                decimal x = a + h * i;
                Xs.Add(x);
                Ys.Add(UserFunction(x));
            }

            Console.WriteLine("Points:");
            for (int i = 0; i < Xs.Count; ++i)
            {
                Console.WriteLine(String.Format("For x = {0}, y = {1}", Xs[i].ToString(), Ys[i].ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            Differentiation differentiation = new Differentiation(Xs, Ys);

            List<decimal> coeffsList = differentiation.GetLagrangeFourthPolynomius(Xs, Ys);
            Console.WriteLine("Polynomius coeffs:");
            foreach (decimal coeff in coeffsList)
            {
                Console.WriteLine(String.Format("\t{0}", coeff.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> firstDerivativeCoeffsList = differentiation.GetFirstDerivativeOfLagrangeFourthPolynomius(Xs, Ys);
            Console.WriteLine("Polynomius first derivative coeffs:");
            foreach (decimal coeff in firstDerivativeCoeffsList)
            {
                Console.WriteLine(String.Format("\t{0}", coeff.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> secondDerivativeCoeffsList = differentiation.GetSecondDerivativeOfLagrangeFourthPolynomius(Xs, Ys);
            Console.WriteLine("Polynomius second derivative coeffs:");
            foreach (decimal coeff in secondDerivativeCoeffsList)
            {
                Console.WriteLine(String.Format("\t{0}", coeff.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            foreach (decimal x in Xs)
            {
                decimal y = differentiation.CalculateLagrangeFourthPolynomius(x, Xs, Ys);
                Console.WriteLine(String.Format("For X = {0}, Y = {1}", x.ToString(), y.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            /// Hand type
            Console.WriteLine("Type x:");
            decimal X = Convert.ToDecimal(Console.ReadLine());

            decimal Y = differentiation.CalculateLagrangeFourthPolynomius(X, Xs, Ys);
            Console.WriteLine(String.Format("For X = {0}, Y = {1}", X.ToString(), Y.ToString()));

            decimal DY = differentiation.CalculateFirstDerivativeOfLagrangeFourthPolynomius(X, Xs, Ys);
            Console.WriteLine(String.Format("For X = {0}, DY = {1}", X.ToString(), DY.ToString()));

            decimal D2Y = differentiation.CalculateSecondDerivativeOfLagrangeFourthPolynomius(X, Xs, Ys);
            Console.WriteLine(String.Format("For X = {0}, D2Y = {1}", X.ToString(), D2Y.ToString()));

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();
            differentiation.Dispose();
        }

        static private void SecondTest()
        {
            int n = 10;
            decimal a = 0;
            decimal b = 7;
            decimal h = (b - a) / n;

            List<decimal> Xs = new List<decimal>();
            List<decimal> Ys = new List<decimal>();
            for (int i = 0; i <= n; ++i)
            {
                decimal x = a + h * i;
                Xs.Add(x);
                Ys.Add(UserFunction(x));
            }

            Console.WriteLine("Points:");
            for (int i = 0; i < Xs.Count; ++i)
            {
                Console.WriteLine(String.Format("For x = {0}, y = {1}", Xs[i].ToString(), Ys[i].ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            Differentiation differentiation = new Differentiation(Xs, Ys);

            List<decimal> firstDerivativesList = differentiation.GetFirstDervative();
            Console.WriteLine("Polynomius first derivative:");
            foreach (decimal dy in firstDerivativesList)
            {
                Console.WriteLine(String.Format("\t{0}", dy.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> secondDerivativesList = differentiation.GetSecondDervative();
            Console.WriteLine("Polynomius second derivative:");
            foreach (decimal d2y in secondDerivativesList)
            {
                Console.WriteLine(String.Format("\t{0}", d2y.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> thirdDerivativesList = differentiation.GetThirdDervative();
            Console.WriteLine("Polynomius third derivative:");
            foreach (decimal d3y in thirdDerivativesList)
            {
                Console.WriteLine(String.Format("\t{0}", d3y.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> fourthDerivativesList = differentiation.GetFourthDervative();
            Console.WriteLine("Polynomius fourth derivative:");
            foreach (decimal d4y in fourthDerivativesList)
            {
                Console.WriteLine(String.Format("\t{0}", d4y.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();
        }

        static private void ThirdTest()
        {
            int n = 100;
            decimal a = 0;
            decimal b = 7;
            decimal h = (b - a) / n;

            List<decimal> Xs = new List<decimal>();
            List<decimal> Ys = new List<decimal>();
            for (int i = 0; i <= n; ++i)
            {
                decimal x = a + h * i;
                Xs.Add(x);
                Ys.Add(UserFunction(x));
            }

            Console.WriteLine("Points:");
            for (int i = 0; i < Xs.Count; ++i)
            {
                Console.WriteLine(String.Format("For x = {0}, y = {1}", Xs[i].ToString(), Ys[i].ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();


            Differentiation differentiation = new Differentiation(Xs, Ys);

            List<decimal> firstDerivativesList = differentiation.CalculateDerivativeByFiniteDifferencies(Xs, Ys);
            Console.WriteLine("Polynomius first derivative:");
            foreach (decimal dy in firstDerivativesList)
            {
                Console.WriteLine(String.Format("\t{0}", dy.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> secondDerivativesList = differentiation.CalculateDerivativeByFiniteDifferencies(Xs, firstDerivativesList);
            Console.WriteLine("Polynomius second derivative:");
            foreach (decimal d2y in secondDerivativesList)
            {
                Console.WriteLine(String.Format("\t{0}", d2y.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            //FirstTest();
            //Console.Read();
            SecondTest();
            //ThirdTest();
            Console.Read();
        }
    }
}
