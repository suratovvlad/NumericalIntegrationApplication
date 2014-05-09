using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.ComponentModel;

using ParserComponent;
using DifferentiationComponent;
using RectangleMethodComponent;
using TrapezoidalRuleComponent;
using SimpsonsRuleComponent;

namespace ClientApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string function = UserFunctionTextBox.Text;

                PostfixNotationExpression parser = new PostfixNotationExpression();
                parser.ToPostfixNotation(function);

                decimal a = Convert.ToDecimal(ParamATextBox.Text);
                decimal b = Convert.ToDecimal(ParamBTextBox.Text);
                decimal n = 1000;
                decimal error = Convert.ToDecimal(ErrorTextBox.Text);

                parser.CalculatePoint(a, b, n);

                List<decimal> Xs = parser.GetXsList();
                List<decimal> Ys = parser.GetYsList();

                Differentiation differentiationComponent = new Differentiation(Xs, Ys);
                
                List<decimal> Dys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, Ys);
                List<decimal> D2ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, Dys);
                List<decimal> D3ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, D2ys);
                List<decimal> D4ys = differentiationComponent.CalculateDerivativeByFiniteDifferencies(Xs, D3ys);

                decimal result = 0;
                decimal partitionCount = 0;

                /// Rectangle Method
                RectangleMethod rectangleMethodComponent = new RectangleMethod();
                partitionCount = rectangleMethodComponent.CalculatePartitionCount(a, b, error, D2ys.Max());

                if (partitionCount == 0)
                {
                    partitionCount = n;
                }

                parser.CalculatePoint(a, b, partitionCount);
                List<decimal> FunctionHalfValues = parser.GetYsHalfList();
                result = rectangleMethodComponent.Calculate(a, b, partitionCount, FunctionHalfValues);
                MessageBox.Show(result.ToString());

                /// Trapezoidal Rule
                TrapezoidalRule trapezoidalRuleComponent = new TrapezoidalRule();
                partitionCount = trapezoidalRuleComponent.CalculatePartitionCount(a, b, error, D2ys.Max());

                if (partitionCount == 0)
                {
                    partitionCount = n;
                }

                parser.CalculatePoint(a, b, partitionCount);
                List<decimal> FunctionValues = parser.GetYsList();
                result = trapezoidalRuleComponent.Calculate(a, b, partitionCount, FunctionValues);
                MessageBox.Show(result.ToString());

                /// Simpson's Rule
                SimpsonsRule simpsonsRuleComponent = new SimpsonsRule();
                partitionCount = simpsonsRuleComponent.CalculatePartitionCount(a, b, error, D4ys.Max());

                if (partitionCount == 0)
                {
                    partitionCount = n;
                }

                parser.CalculatePoint(a, b, partitionCount);
                FunctionHalfValues = parser.GetYsHalfList();
                FunctionValues = parser.GetYsList();
                result = simpsonsRuleComponent.Calculate(a, b, partitionCount, FunctionValues, FunctionHalfValues);
                MessageBox.Show(result.ToString());

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }    
        }
    }
}
