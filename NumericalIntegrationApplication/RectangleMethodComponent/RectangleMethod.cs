﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace RectangleMethodComponent
{
    public class RectangleMethod : Component
    {
        public decimal CalculatePartitionCount(decimal a, decimal b, decimal error, decimal maxSecondDerivative)
        {
            decimal n = 0;

            n = (b - a) * (b - a) * (b - a);
            n /= (24 * error);
            n *= maxSecondDerivative;
            n = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(n)));

            return n;
        }

        public decimal Calculate(decimal a, decimal b, decimal n, List<decimal> FunctionValues)
        {
            decimal result = 0;

            foreach (decimal value in FunctionValues)
            {
                result += value;
            }

            result *= ((b - a) / n);

            return result;
        }
    }
}
