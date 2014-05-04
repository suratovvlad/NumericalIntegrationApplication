using System;
using ParserComponent;

namespace ParserComponentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PostfixNotationExpression parser = new PostfixNotationExpression();

            string expression = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            parser.ToPostfixNotation(expression);
            string[] strArr = parser.GetLastPostfixNotation();

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
