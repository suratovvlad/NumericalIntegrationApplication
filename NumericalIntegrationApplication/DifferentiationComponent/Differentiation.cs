using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;

namespace DifferentiationComponent
{
    public class Differentiation : Component
    {
        private List<decimal> m_Xs;
        private List<decimal> m_Ys;
        private List<decimal> m_Dys;
        private List<decimal> m_D2ys;

        public Differentiation(List<decimal> Xs, List<decimal> Ys)
        {
            m_Xs = new List<decimal>(Xs);
            m_Ys = new List<decimal>(Ys);
            m_Dys = new List<decimal>();
            m_D2ys = new List<decimal>();
        }

        public List<decimal> GetDerivative()
        {

            return m_Dys;
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

        private List<decimal> GetLagrangeFourthPolynomius(List<decimal> Xs, List<decimal> Ys)
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

        private List<decimal> GetStandartFourthPolynomius(List<decimal> constantsList)
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

        private decimal LagrangeMethod(decimal x)
        {
            decimal result = 0;
            
            for (int i = 0; i < m_Xs.Count; ++i)
            {
                decimal l = 0;
                for (int j = 0; j < m_Xs.Count; ++j)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    l *= (x - m_Xs.ToArray()[j]) / (m_Xs.ToArray()[i] - m_Xs.ToArray()[j]);
                }
                result += (l * m_Ys.ToArray()[i]);
            }

            return result;
        }

        private decimal derivativeLagrange(int t)
        {
            decimal result = 0;

            for (int i = 0; i < m_Xs.Count; ++i)
            {
                //int num = m_Xs.Count - 1 - i;
                //Math.Pow((-1), num);

                //Factorial(i) * Factorial(num);

            }

            return result;
        }

      
        private int Factorial(int numb)
        {
            int res = 1;
            for (int i = numb; i > 1; i--)
            {
                res *= i;
            }               
            return res;
        }
    }
}
