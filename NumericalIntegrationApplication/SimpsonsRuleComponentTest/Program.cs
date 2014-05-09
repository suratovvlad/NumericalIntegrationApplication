using System;
using System.Collections.Generic;
using System.Linq;

using DifferentiationComponent;
using SimpsonsRuleComponent;
using ParserComponent;

namespace SimpsonsRuleComponentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal n = 1000;
            decimal a = 0;
            decimal b = 1;
            decimal error = Convert.ToDecimal(0.000001);

            string function = "ln((1+x)/(1-x))";
            PostfixNotationExpression parser = new PostfixNotationExpression();
            parser.ToPostfixNotation(function);

            parser.CalculatePoint(a, b, n);

            List<decimal> Xs = parser.GetXsList();
            List<decimal> Ys = parser.GetYsList();

            Differentiation differentiationComponent = new Differentiation(Xs, Ys);

            List<decimal> Dys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, Ys);
            List<decimal> D2ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, Dys);
            List<decimal> D3ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, D2ys);
            List<decimal> D4ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, D3ys);

            decimal result = 0;
            decimal partitionCount = 0;

            /// Simpson's Rule
            SimpsonsRule simpsonsRuleComponent = new SimpsonsRule();
            partitionCount = simpsonsRuleComponent.CalculatePartitionCount(a, b, error, D4ys.Max());

            if (partitionCount == 0)
            {
                partitionCount = n;
            }

            parser.CalculatePoint(a, b, partitionCount);
            List<decimal> FunctionHalfValues = parser.GetYsHalfList();
            List<decimal> FunctionValues = parser.GetYsList();
            result = simpsonsRuleComponent.Calculate(a, b, partitionCount, FunctionValues, FunctionHalfValues);

            Console.WriteLine(String.Format("Result: {0}", result));
            Console.Read();
        }
    }
}
