using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace TrapezoidalRuleComponent
{
    public class TrapezodialRule : Component
    {

        public decimal CalculatePartitionCount(decimal a, decimal b, decimal error, decimal maxSecondDerivative)
        {
            decimal n = 0;

            n = (b - a) * (b - a) * (b - a);
            n /= (12 * error);
            n *= maxSecondDerivative;
            n = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(n)));

            return n;
        }

        public decimal Calculate(decimal a, decimal b, decimal n, List<decimal> FunctionValues)
        {
            decimal result = 0;

            for (int i = 1; i < FunctionValues.Count - 1; ++i)
            {
                result += FunctionValues[i];
            }

            result += ((FunctionValues[0] + FunctionValues[FunctionValues.Count - 1]) / 2);

            result *= ((b - a) / n);

            return result;
        }
    }


}
