using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserComponent
{
    public class PostfixNotationExpression
    {
        private List<string> m_operators;
        private List<string> m_standartOperators;

        public PostfixNotationExpression()
        {
            m_standartOperators = new List<string>(new string[] { "(", ")", "+", "-", "*", "/", "^" });
            m_operators = new List<string>(m_standartOperators);
        }

        private IEnumerable<string> Separate(string input)
        {
            int pos = 0;
            while (pos < input.Length)
            {
                string s = string.Empty + input[pos];
                if (!m_standartOperators.Contains(input[pos].ToString()))
                {
                    if (Char.IsDigit(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsDigit(input[i]) || input[i] == ',' || input[i] == '.'); i++)
                            s += input[i];
                    else if (Char.IsLetter(input[pos]))
                        for (int i = pos + 1; i < input.Length &&
                            (Char.IsLetter(input[i]) || Char.IsDigit(input[i])); i++)
                            s += input[i];
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
                    return 2;
                case "-":
                    return 3;
                case "*":
                case "/":
                    return 4;
                case "^":
                    return 5;
                default:
                    return 6;
            }
        }

       private string[] ConvertToPostfixNotation(string input)
        {
            List<string> outputSeparated = new List<string>();
            Stack<string> stack = new Stack<string>();

            foreach (string c in Separate(input))
            {
                if (m_operators.Contains(c))
                {
                    if (stack.Count > 0 && !c.Equals("("))
                    {
                        if (c.Equals(")"))
                        {
                            string s = stack.Pop();
                            while (s != "(")
                            {
                                outputSeparated.Add(s);
                                s = stack.Pop();
                            }
                        }
                        else if (GetPriority(c) >= GetPriority(stack.Peek()))
                        {
                            stack.Push(c);
                        }
                        else
                        {
                            while (stack.Count > 0 && GetPriority(c) < GetPriority(stack.Peek()))
                            {
                                outputSeparated.Add(stack.Pop());
                            }
                            stack.Push(c);
                        }
                    }
                    else
                    {
                        stack.Push(c);
                    }                    
                }
                else
                {
                    outputSeparated.Add(c);
                }
            }
            if (stack.Count > 0)
            {
                foreach (string c in stack)
                {
                    outputSeparated.Add(c);
                }
            }
            return outputSeparated.ToArray();
        }

        public decimal Result(string input)
        {
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>(ConvertToPostfixNotation(input));
            string str = queue.Dequeue();

            while (queue.Count >= 0)
            {
                if (!m_operators.Contains(str))
                {
                    stack.Push(str);
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
    }
}
