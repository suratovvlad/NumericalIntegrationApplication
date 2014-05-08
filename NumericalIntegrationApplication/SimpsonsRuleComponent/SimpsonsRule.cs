using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SimpsonsRuleComponent
{
    public class SimpsonsRule : Component
    {
        public decimal CalculatePartitionCount(decimal a, decimal b, decimal error, decimal maxFourthDerivative)
        {
            decimal n = 0;

            n = (b - a) * (b - a) * (b - a) * (b - a) * (b - a);
            n /= (180 * error);
            n *= maxFourthDerivative;
            n = Convert.ToDecimal(Math.Sqrt(Math.Sqrt(Convert.ToDouble(n))));
            n /= 2;

            return n;
        }

        public decimal Calculate(decimal a, decimal b, decimal n, List<decimal> FunctionValues, List<decimal> FunctionHalfValues)
        {
            decimal result = 0;

            result += (FunctionValues[0] + FunctionValues[FunctionValues.Count - 1]);

            for (int i = 1; i < FunctionValues.Count - 1; ++i)
            {
                result += (FunctionValues[i] * 2);
            }
            
            foreach (decimal value in FunctionHalfValues)
            {
                result += (value * 4);
            }

            result *= ((b - a) / (6 * n));

            return result;
        }
    }
}
