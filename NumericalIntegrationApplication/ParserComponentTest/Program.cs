﻿using System;
using System.Collections.Generic;
using ParserComponent;
using System.Windows;

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

            //List<string> paramsList = new List<string>();

            //List<string> parameters = parser.GetParameterList();
            //if (parameters.Count > 0)
            //{
            //    Console.WriteLine("Set parameters as decimal:");
            //}
            //foreach (string str in parameters)
            //{
            //    Console.WriteLine(str + " = ");
            //    paramsList.Add(Console.ReadLine());
            //}

            //Console.WriteLine("Result = " + parser.Result(paramsList.ToArray()));


            //Console.WriteLine();
            //Console.WriteLine(".................");
            //Console.WriteLine();

            

            foreach (string str in strArr)
            {
                Console.Write(str);
                Console.Write(" ");
            }

            parser.CalculatePoint(-2, 7, 100);

            /// In suggestion that counts of Xs and Ys are equal
            List<decimal> Xs = parser.GetXsList();
            List<decimal> Ys = parser.GetYsList();

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine("Points:");
            for (int i = 0; i < Xs.Count; ++i)
            {
                Console.WriteLine(String.Format("\tx = {0}\ty = {1}", Xs.ToArray()[i].ToString(), Ys.ToArray()[i].ToString()));
            }


            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine();

            List<decimal> XsHalf = parser.GetXsHalfList();
            List<decimal> YsHalf = parser.GetYsHalfList();

            Console.WriteLine();
            Console.WriteLine(".................");
            Console.WriteLine("Points:");
            for (int i = 0; i < XsHalf.Count; ++i)
            {
                Console.WriteLine(String.Format("\tx = {0}\ty = {1}", XsHalf.ToArray()[i].ToString(), YsHalf.ToArray()[i].ToString()));
            }

            parser.Dispose();
            Console.Read();
        }
    }
}
