using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using ParserComponent;

namespace ParserComponentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            PostfixNotationExpression parser = new PostfixNotationExpression();

            string expression = Console.ReadLine();

            //decimal result = parser.Result(expression);
            //Console.WriteLine(result.ToString());

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
