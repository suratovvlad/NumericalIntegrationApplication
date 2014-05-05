using System;
using System.Collections.Generic;
using DifferentiationComponent;

namespace DifferentiationComponentTest
{
    class Program
    {
        static private decimal UserFunction(decimal x)
        {
            return Convert.ToDecimal(Math.Cos(Convert.ToDouble(x)));
        }

        static void Main(string[] args)
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

            //List<decimal> coeffsList = differentiation.GetLagrangeFourthPolynomius(Xs, Ys);
            //Console.WriteLine("Coeffs of polynomius:");
            //foreach (decimal coeff in coeffsList)
            //{
            //    Console.WriteLine(String.Format("\t{0}", coeff.ToString()));
            //}

            //Console.WriteLine();
            //Console.WriteLine(".................");
            //Console.WriteLine();

            foreach (decimal x in Xs)
            {
                decimal y = differentiation.CalculateLagrangeFourthPolynomius(x, Xs, Ys);
                Console.WriteLine(String.Format("For X = {0}, Y = {1}", x.ToString(), y.ToString()));
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            Console.WriteLine("Type x:");
            decimal X = Convert.ToDecimal(Console.ReadLine());

            decimal Y = differentiation.CalculateLagrangeFourthPolynomius(X, Xs, Ys);

            Console.WriteLine(String.Format("For X = {0}, Y = {1}", X.ToString(), Y.ToString()));

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            differentiation.Dispose();
            Console.Read();
        }
    }
}
