using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace ParserComponent
{
    public class PostfixNotationExpression : Component
    {
        private List<string> m_operators;
        List<string> m_outputSeparated;
        List<string> m_parametersList;
        const string m_pattern = @"^\-?\(?([0-9]{0,3}(\,?[0-9]{3})*(\.?[0-9]*))\)?$";

        public PostfixNotationExpression()
        {
            m_operators = new List<string>(
                new string[]
                {
                    "(", ")", "+", "-", "*", "/", "^", "sin", "cos", "tan", "ln"
                }
            );
            m_outputSeparated = new List<string>();
            m_parametersList = new List<string>();
        }

        private IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!m_operators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                    {
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                        {
                            s += input[i];
                        }
                    }
                    else if (Char.IsLetter(input[pos]))
                    {
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                        {
                            s += input[i];
                        }
                    }
                        
                }
                yield return s;
                pos += s.Length;
            }
        }

        private byte GetPriority(string s)
        {
            switch (s)
            {
                case "(":
                    return 0;
                case ")":
                    return 1;
                case "+":
                case "-":
                    return 2;
                case "*":
                case "/":
                    return 3;
                case "^":
                    return 4;
                case "sin":
                case "cos":
                case "tan":
                case "ln":
                    return 5;
                default:
                    return 6;
            }
        }

        private void FindParameters()
        {
            List<string> newOutput = new List<string>();
            foreach (string str in m_outputSeparated)
            {
                if (!m_operators.Contains(str))
                {
                    Regex regex = new Regex(m_pattern);
                    if (regex.IsMatch(str))
                    {
                        newOutput.Add(str);
                        continue;
                    }
                    m_parametersList.Add(str);
                    newOutput.Add("{" + m_parametersList.IndexOf(str).ToString() + "}");
                }
                else
                {
                    newOutput.Add(str);
                }
            }
            m_outputSeparated = newOutput;
        }

        public List<string> GetParameterList()
        {
            return m_parametersList;
        }

        private void ConvertToPostfixNotation(string input)
        {
            m_outputSeparated.Clear();
            Stack<string> stack = new Stack<string>();

            foreach (string c in Separate(input))
            {
                if (c.Equals(" "))
                {
                    continue;
                }
                else if (m_operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                m_outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) >= GetPriority(stack.Peek()))
                        {
                            stack.Push(c);
                        }
                        else
                        {
                            // GetPriority(c) < GetPriority(stack.Peek())
                            while (stack.Count > 0 && GetPriority(c) < GetPriority(stack.Peek()))
                            {
                                m_outputSeparated.Add(stack.Pop());
                            }
                            stack.Push(c);
                        }
                    }
                    else
                    {
                        // "(" here
                        stack.Push(c);
                    }
                }
                else
                {
                    // Parameter or Constant
                    m_outputSeparated.Add(c);
                }
            }
            if (stack.Count > 0)
            {
                foreach (string c in stack)
                {
                    m_outputSeparated.Add(c);
                }
            }

            FindParameters();
        }

        public decimal Calculate(string[] paramList)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>(m_outputSeparated.ToArray());
            string str = queue.Dequeue();

            while (queue.Count >= 0)
            {
                if (!m_operators.Contains(str))
                {
                    Regex regex = new Regex(m_pattern);
                    if (!regex.IsMatch(str))
                    {
                        stack.Push(paramList[Convert.ToInt32(str.Substring(1, str.Length - 2))]);
                    }
                    else
                    {
                        stack.Push(str);
                    }

                    str = queue.Dequeue();
                }
                else
                {
                    decimal summ = 0;
                    switch (str)
                    {
                        case "+":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                decimal b = Convert.ToDecimal(stack.Pop());
                                summ = b + a;
                                break;
                            }
                        case "-":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                decimal b = Convert.ToDecimal(stack.Pop());
                                summ = b - a;
                                break;
                            }
                        case "*":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                decimal b = Convert.ToDecimal(stack.Pop());
                                summ = b * a;
                                break;
                            }
                        case "/":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                decimal b = Convert.ToDecimal(stack.Pop());
                                summ = b / a;
                                break;
                            }
                        case "^":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                decimal b = Convert.ToDecimal(stack.Pop());
                                summ = Convert.ToDecimal(Math.Pow(Convert.ToDouble(b), Convert.ToDouble(a)));
                                break;
                            }
                        case "sin":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                summ = Convert.ToDecimal(Math.Sin(Convert.ToDouble(a)));
                                break;
                            }
                        case "cos":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                summ = Convert.ToDecimal(Math.Cos(Convert.ToDouble(a)));
                                break;
                            }
                        case "tan":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                summ = Convert.ToDecimal(Math.Tan(Convert.ToDouble(a)));
                                break;
                            }
                        case "ln":
                            {
                                decimal a = Convert.ToDecimal(stack.Pop());
                                summ = Convert.ToDecimal(Math.Log(Convert.ToDouble(a)));
                                break;
                            }
                    }
                    stack.Push(summ.ToString());
                    if (queue.Count > 0)
                    {
                        str = queue.Dequeue();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return Convert.ToDecimal(stack.Pop());
        }

        public void ToPostfixNotation(string input)
        {
            ConvertToPostfixNotation(input);
        }

        public string[] GetInPostfixNotation(string input)
        {
            ConvertToPostfixNotation(input);
            return m_outputSeparated.ToArray();
        }

        public string[] GetLastPostfixNotation()
        {
            return m_outputSeparated.ToArray();
        }

        public decimal Result(string[] paramList)
        {
            return Calculate(paramList);
        }

        public List<Point> getPointsList(decimal a, decimal b, decimal n)
        {
            List<Point> pointsList = new List<Point>();

            decimal h = (a + b) / n;

            for (int i = 0; i < n; i++)
            {
                List<string> paramList = new List<string>();
                decimal x = a + h * i;
                paramList.Add(Convert.ToString(x));
                decimal y = Calculate(paramList.ToArray());
                Point point = new Point(Convert.ToDouble(x), Convert.ToDouble(y));
                pointsList.Add(point);
            }
            
            

            return pointsList;
        }
    }
}
