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
        private static List<string> m_methods;

        public MainForm()
        {
            InitializeComponent();
            m_methods = new List<string>(new string[] { "Rectangle Method", "Trapezoidal Rule", "Simpson's Rule", "All of these methods" });
            MethodsComboBox.DataSource = m_methods;
            MethodsComboBox.SelectedIndex = 0;
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                string method = MethodsComboBox.SelectedItem.ToString();               

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

                switch (method)
                {
                    case "Rectangle Method":
                        {
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
                            MessageBox.Show("Rectangle Method:\n" + result.ToString());
                            rectangleMethodComponent.Dispose();
                            break;
                        }
                    case "Trapezoidal Rule":
                        {
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
                            MessageBox.Show("Trapezoidal Rule:\n" + result.ToString());
                            trapezoidalRuleComponent.Dispose();
                            break;
                        }
                    case "Simpson's Rule":
                        {
                            /// Simpson's Rule
                            SimpsonsRule simpsonsRuleComponent = new SimpsonsRule();
                            partitionCount = simpsonsRuleComponent.CalculatePartitionCount(a, b, error, D4ys.Max());

                            if (partitionCount == 0)
                            {
                                partitionCount = n;
                            }

                            parser.CalculatePoint(a, b, partitionCount);
                            List<decimal> FunctionHalfValues = parser.GetYsHalfList();
                            List<decimal> FunctionValues = parser.GetYsList();
                            result = simpsonsRuleComponent.Calculate(a, b, partitionCount, FunctionValues, FunctionHalfValues);
                            MessageBox.Show("Simpson's Rule:\n" + result.ToString());
                            simpsonsRuleComponent.Dispose();
                            break;
                        }
                    case "All of these methods":
                        {
                            Container container = new Container();

                            RectangleMethod rectangleMethodComponent = new RectangleMethod();
                            TrapezoidalRule trapezoidalRuleComponent = new TrapezoidalRule();
                            SimpsonsRule simpsonsRuleComponent = new SimpsonsRule();

                            container.Add(rectangleMethodComponent, "Rectangle Method");
                            container.Add(trapezoidalRuleComponent, "Trapezoidal Rule");
                            container.Add(simpsonsRuleComponent, "Simpson's Rule");

                            string message = "All methods\n\n";

                            /// Rectangle Method
                            partitionCount = rectangleMethodComponent.CalculatePartitionCount(a, b, error, D2ys.Max());

                            if (partitionCount == 0)
                            {
                                partitionCount = n;
                            }

                            parser.CalculatePoint(a, b, partitionCount);
                            List<decimal> FunctionHalfValues = parser.GetYsHalfList();
                            result = rectangleMethodComponent.Calculate(a, b, partitionCount, FunctionHalfValues);

                            message += rectangleMethodComponent.Site.Name + ":\n" + result.ToString() + "\n";

                            /// Trapezoidal Rule
                            partitionCount = trapezoidalRuleComponent.CalculatePartitionCount(a, b, error, D2ys.Max());

                            if (partitionCount == 0)
                            {
                                partitionCount = n;
                            }

                            parser.CalculatePoint(a, b, partitionCount);
                            List<decimal> FunctionValues = parser.GetYsList();
                            result = trapezoidalRuleComponent.Calculate(a, b, partitionCount, FunctionValues);

                            message += trapezoidalRuleComponent.Site.Name + ":\n" + result.ToString() + "\n";

                            /// Simpson's Rule
                            partitionCount = simpsonsRuleComponent.CalculatePartitionCount(a, b, error, D4ys.Max());

                            if (partitionCount == 0)
                            {
                                partitionCount = n;
                            }

                            parser.CalculatePoint(a, b, partitionCount);
                            FunctionHalfValues = parser.GetYsHalfList();
                            FunctionValues = parser.GetYsList();
                            result = simpsonsRuleComponent.Calculate(a, b, partitionCount, FunctionValues, FunctionHalfValues);

                            message += simpsonsRuleComponent.Site.Name + ":\n" + result.ToString();
                            MessageBox.Show(message);

                            container.Dispose();
                            break;
                        }
                    default:
                        {
                            MessageBox.Show("Choose method");
                            break;
                        }
                }

                differentiationComponent.Dispose();
                parser.Dispose();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }    
        }
    }
}
