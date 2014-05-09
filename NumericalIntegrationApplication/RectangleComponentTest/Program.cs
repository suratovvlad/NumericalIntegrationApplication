using System;
using System.Collections.Generic;
using System.Linq;

using DifferentiationComponent;
using RectangleMethodComponent;
using ParserComponent;

namespace RectangleComponentTest
{
    class Program
    {

        static void Main(string[] args)
        {
            decimal n = 1000;
            decimal a = 0;
            decimal b = 1;
            decimal error = Convert.ToDecimal(0.0001);

            string function = "ln((1+x)/(1-x))";
            PostfixNotationExpression parser = new PostfixNotationExpression();
            parser.ToPostfixNotation(function);

            parser.CalculatePoint(a, b, n);

            List<decimal> Xs = parser.GetXsList();
            List<decimal> Ys = parser.GetYsList();

            Differentiation differentiationComponent = new Differentiation(Xs, Ys);

            List<decimal> Dys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, Ys);
            List<decimal> D2ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, Dys);

            decimal result = 0;
            decimal partitionCount = 0;

            /// Rectangle Method
            RectangleMethod rectangleMethodComponent = new RectangleMethod();
            partitionCount = rectangleMethodComponent.CalculatePartitionCount(a, b, error, D2ys.Max());

            if (partitionCount == 0)
            {
                partitionCount = n;
            }

            parser.CalculatePoint(a, b, partitionCount);
            List<decimal> FunctionHalfValues = parser.GetYsHalfList();
            result = rectangleMethodComponent.Calculate(a, b, partitionCount, FunctionHalfValues);

            Console.WriteLine(String.Format("Result: {0}", result));
            Console.Read();
        }
    }
}
