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
