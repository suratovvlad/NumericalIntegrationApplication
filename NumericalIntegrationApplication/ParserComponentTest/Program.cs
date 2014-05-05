using System;
using System.Collections.Generic;
using ParserComponent;

namespace ParserComponentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PostfixNotationExpression parser = new PostfixNotationExpression();

            string expression = Console.ReadLine();

            parser.ToPostfixNotation(expression);
            string[] strArr = parser.GetLastPostfixNotation();

            List<string> paramsList = new List<string>();

            List<string> parameters = parser.GetParameterList();
            if (parameters.Count > 0)
            {
                Console.WriteLine("Set parameters as decimal:");
            }
            foreach (string str in parameters)
            {
                Console.WriteLine(str + " = ");
                paramsList.Add(Console.ReadLine());
            }

            Console.WriteLine("Result = " + parser.Result(paramsList.ToArray()));


            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            

            foreach (string str in strArr)
            {
                Console.Write(str);
                Console.Write(" ");
            }

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            parser.Dispose();
            Console.Read();
        }
    }
}
