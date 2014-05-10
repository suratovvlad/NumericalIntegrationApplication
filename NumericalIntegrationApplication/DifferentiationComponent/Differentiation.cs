using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DifferentiationComponent
{
    public class Differentiation : Component
    {
        private List<decimal> m_Xs;
        private List<decimal> m_Ys;
        private List<decimal> m_Dys;
        private List<decimal> m_D2ys;
        private List<decimal> m_D3ys;
        private List<decimal> m_D4ys;

        public List<decimal> CalculateDerivativeByFiniteDifferencies(List<decimal> Xs, List<decimal> Ys)
        {
            List<decimal> Dys = new List<decimal>();

            for (int i = 1; i < Ys.Count; ++i)
            {
                decimal dy = (Ys[i] - Ys[i - 1]) / (Xs[i] - Xs[i - 1]);
                Dys.Add(dy);
            }
            return Dys;
        }

        public Differentiation(List<decimal> Xs, List<decimal> Ys)
        {
            m_Xs = new List<decimal>(Xs);
            m_Ys = new List<decimal>(Ys);
            CalculateDerivatives();
        }

        private void CalculateDerivatives()
        {
            decimal[] Dys = new decimal[m_Xs.Count];
            decimal[] D2ys = new decimal[m_Xs.Count];
            decimal[] D3ys = new decimal[m_Xs.Count];
            decimal[] D4ys = new decimal[m_Xs.Count];

            for (int i = 0; i < m_Xs.Count; ++i)
            {
                Dys[i] = 0;
                D2ys[i] = 0;
                D3ys[i] = 0;
                D4ys[i] = 0;
            }

            for (int i = 4; i < m_Xs.Count; i += 4)
            {
                List<decimal> Xs = new List<decimal>();
                List<decimal> Ys = new List<decimal>();

                for (int j = i - 4; j <= i; ++j)
                {
                    Xs.Add(m_Xs[j]);
                    Ys.Add(m_Ys[j]);                    
                }

                for (int j = 0; j <= 4; ++j)
                {
                    /// First
                    if (Dys[i - 4 + j] != 0)
                    {
                        Dys[i - 4 + j] += CalculateFirstDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                        Dys[i - 4 + j] /= 2;
                    }
                    else
                    {
                        Dys[i - 4 + j] = CalculateFirstDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                    }

                    /// Second
                    if (D2ys[i - 4 + j] != 0)
                    {
                        D2ys[i - 4 + j] += CalculateSecondDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                        D2ys[i - 4 + j] /= 2;
                    }
                    else
                    {
                        D2ys[i - 4 + j] = CalculateSecondDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                    }

                    /// Third
                    if (D3ys[i - 4 + j] != 0)
                    {
                        D3ys[i - 4 + j] += CalculateThirdDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                        D3ys[i - 4 + j] /= 2;
                    }
                    else
                    {
                        D3ys[i - 4 + j] = CalculateThirdDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                    }

                    /// Fourth
                    if (D4ys[i - 4 + j] != 0)
                    {
                        D4ys[i - 4 + j] += CalculateFourthDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                        D4ys[i - 4 + j] /= 2;
                    }
                    else
                    {
                        D4ys[i - 4 + j] = CalculateFourthDerivativeOfLagrangeFourthPolynomius(m_Xs[i - 4 + j], Xs, Ys);
                    }
                }
                
            }

            m_Dys = new List<decimal>(Dys);
            m_D2ys = new List<decimal>(D2ys);
            m_D3ys = new List<decimal>(D3ys);
            m_D4ys = new List<decimal>(D4ys);
        }

        public List<decimal> GetFirstDervative()
        {
            return m_Dys;
        }

        public List<decimal> GetSecondDervative()
        {
            return m_D2ys;
        }

        public List<decimal> GetThirdDervative()
        {
            return m_D3ys;
        }

        public List<decimal> GetFourthDervative()
        {
            return m_D4ys;
        }

        public decimal CalculateFourthDerivativeOfLagrangeFourthPolynomius(decimal x, List<decimal> Xs, List<decimal> Ys)
        {
            List<decimal> derivativeCoeffsLagrangeList = GetFourthDerivativeOfLagrangeFourthPolynomius(Xs, Ys);
            double result = 0;

            for (int i = 0; i < derivativeCoeffsLagrangeList.Count; ++i)
            {
                result += Convert.ToDouble(derivativeCoeffsLagrangeList[i]) * Math.Pow(Convert.ToDouble(x), Convert.ToDouble(i));
            }
            return Convert.ToDecimal(result);
        }

        public decimal CalculateThirdDerivativeOfLagrangeFourthPolynomius(decimal x, List<decimal> Xs, List<decimal> Ys)
        {
            List<decimal> derivativeCoeffsLagrangeList = GetThirdDerivativeOfLagrangeFourthPolynomius(Xs, Ys);
            double result = 0;

            for (int i = 0; i < derivativeCoeffsLagrangeList.Count; ++i)
            {
                result += Convert.ToDouble(derivativeCoeffsLagrangeList[i]) * Math.Pow(Convert.ToDouble(x), Convert.ToDouble(i));
            }
            return Convert.ToDecimal(result);
        }

        public decimal CalculateSecondDerivativeOfLagrangeFourthPolynomius(decimal x, List<decimal> Xs, List<decimal> Ys)
        {
            List<decimal> derivativeCoeffsLagrangeList = GetSecondDerivativeOfLagrangeFourthPolynomius(Xs, Ys);
            double result = 0;

            for (int i = 0; i < derivativeCoeffsLagrangeList.Count; ++i)
            {
                result += Convert.ToDouble(derivativeCoeffsLagrangeList[i]) * Math.Pow(Convert.ToDouble(x), Convert.ToDouble(i));
            }
            return Convert.ToDecimal(result);
        }

        public decimal CalculateFirstDerivativeOfLagrangeFourthPolynomius(decimal x, List<decimal> Xs, List<decimal> Ys)
        {
            List<decimal> derivativeCoeffsLagrangeList = GetFirstDerivativeOfLagrangeFourthPolynomius(Xs, Ys);
            double result = 0;

            for (int i = 0; i < derivativeCoeffsLagrangeList.Count; ++i)
            {
                result += Convert.ToDouble(derivativeCoeffsLagrangeList[i]) * Math.Pow(Convert.ToDouble(x), Convert.ToDouble(i));
            }
            return Convert.ToDecimal(result);
        }

        public decimal CalculateLagrangeFourthPolynomius(decimal x, List<decimal> Xs, List<decimal> Ys)
        {
            List<decimal> coeffsLagrangeList = GetLagrangeFourthPolynomius(Xs, Ys);
            double result = 0;

            for (int i = 0; i < coeffsLagrangeList.Count; ++i)
            {
                result += Convert.ToDouble(coeffsLagrangeList[i]) * Math.Pow(Convert.ToDouble(x), Convert.ToDouble(i));
            }
            return Convert.ToDecimal(result);
        }

        public List<decimal> GetFourthDerivativeOfLagrangeFourthPolynomius(List<decimal> Xs, List<decimal> Ys)
        {
            /// Xs.Count == Ys.Count == 5
            /// coeffsArray.Length == 5
            /// But returnValue.Count == 1
            decimal[] coeffsArray = GetThirdDerivativeOfLagrangeFourthPolynomius(Xs, Ys).ToArray();
            List<decimal> derivativeCoeffsList = new List<decimal>();
            for (int i = 0; i < coeffsArray.Length; ++i)
            {
                coeffsArray[i] *= i;
                if (i != 0)
                {
                    derivativeCoeffsList.Add(coeffsArray[i]);
                }
            }
            return derivativeCoeffsList;
        }

        public List<decimal> GetThirdDerivativeOfLagrangeFourthPolynomius(List<decimal> Xs, List<decimal> Ys)
        {
            /// Xs.Count == Ys.Count == 5
            /// coeffsArray.Length == 5
            /// But returnValue.Count == 2
            decimal[] coeffsArray = GetSecondDerivativeOfLagrangeFourthPolynomius(Xs, Ys).ToArray();
            List<decimal> derivativeCoeffsList = new List<decimal>();
            for (int i = 0; i < coeffsArray.Length; ++i)
            {
                coeffsArray[i] *= i;
                if (i != 0)
                {
                    derivativeCoeffsList.Add(coeffsArray[i]);
                }
            }
            return derivativeCoeffsList;
        }

        public List<decimal> GetSecondDerivativeOfLagrangeFourthPolynomius(List<decimal> Xs, List<decimal> Ys)
        {
            /// Xs.Count == Ys.Count == 5
            /// coeffsArray.Length == 5
            /// But returnValue.Count == 3
            decimal[] coeffsArray = GetFirstDerivativeOfLagrangeFourthPolynomius(Xs, Ys).ToArray();
            List<decimal> derivativeCoeffsList = new List<decimal>();
            for (int i = 0; i < coeffsArray.Length; ++i)
            {
                coeffsArray[i] *= i;
                if (i != 0)
                {
                    derivativeCoeffsList.Add(coeffsArray[i]);
                }
            }
            return derivativeCoeffsList;
        }

        public List<decimal> GetFirstDerivativeOfLagrangeFourthPolynomius(List<decimal> Xs, List<decimal> Ys)
        {
            /// Xs.Count == Ys.Count == 5
            /// coeffsArray.Length == 5
            /// But returnValue.Count == 4
            decimal[] coeffsArray = GetLagrangeFourthPolynomius(Xs, Ys).ToArray();
            List<decimal> derivativeCoeffsList = new List<decimal>();
            for (int i = 0; i < coeffsArray.Length; ++i)
            {
                coeffsArray[i] *= i;
                if (i != 0)
                {
                    derivativeCoeffsList.Add(coeffsArray[i]);
                }
            }
            return derivativeCoeffsList;
        }

        public List<decimal> GetLagrangeFourthPolynomius(List<decimal> Xs, List<decimal> Ys)
        {
            /// Xs.Count == Ys.Count == 5
            decimal[] coeffsLagrangeArray = new decimal[Xs.Count];
            for (int i = 0; i < Xs.Count; ++i)
            {
                coeffsLagrangeArray[i] = 0;
            }

            for (int i = 0; i < Xs.Count; ++i)
            {                
                decimal coeff = 1;
                List<decimal> constantsList = new List<decimal>();
                for (int j = 0; j < Xs.Count; ++j)
                {
                    if (i != j)
                    {
                        constantsList.Add(Xs[j]);
                        coeff *= (Xs[i] - Xs[j]);
                    }
                }

                decimal[] coeffsStandartArray = GetStandartFourthPolynomius(constantsList).ToArray();
                for (int j = 0; j < coeffsStandartArray.Length; j++)
                {
                    coeffsStandartArray[j] *= Ys[i];
                    coeffsStandartArray[j] /= coeff;
                    coeffsLagrangeArray[j] += coeffsStandartArray[j];
                }

            }

            List<decimal> lagrangeCoeffsList = new List<decimal>(coeffsLagrangeArray);
            return lagrangeCoeffsList;
        }

        public List<decimal> GetStandartFourthPolynomius(List<decimal> constantsList)
        {
            /// constantsList.Count == 4
            /// a, b, c, d
            decimal a = constantsList[0];
            decimal b = constantsList[1];
            decimal c = constantsList[2];
            decimal d = constantsList[3];

            List<decimal> coeffList = new List<decimal>();

            decimal coeff0 = a * b * c * d;
            decimal coeff1 = a * b * c + a * b * d + a * c * d + b * c * d;
            coeff1 *= (-1);
            decimal coeff2 = a * b + a * c + a * d + b * c + b * d + c * d;
            decimal coeff3 = a + b + c + d;
            coeff3 *= (-1);
            decimal coeff4 = 1;

            coeffList.Add(coeff0);
            coeffList.Add(coeff1);
            coeffList.Add(coeff2);
            coeffList.Add(coeff3);
            coeffList.Add(coeff4);

            return coeffList;
        }

    }
}
