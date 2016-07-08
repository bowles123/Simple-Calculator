using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        private Queue<int> operands;
        private Queue<char> operators;
        private int number;

        public Queue<int> Operands { get { return operands; } }
        public Queue<char> Operators { get { return operators; } }
        public int Number { get { return number; } }

        public Calculator()
        {
            operands = new Queue<int>();
            operators = new Queue<char>();
            InitializeComponent();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            number *= 10;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
                calculatorScreen.Text = number.ToString();
            else
                calculatorScreen.Text += 0.ToString();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 1;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 1.ToString();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 2;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 2.ToString();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 3;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 3.ToString();
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 4;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 4.ToString();
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 5;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 5.ToString();
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 6;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 6.ToString();
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 7;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 7.ToString();
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 8;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 8.ToString();
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            number *= 10;
            number += 9;

            if (operands.Count == 0 || calculatorScreen.Text.Contains("="))
            {
                operands.Clear();
                calculatorScreen.Text = number.ToString();
            }
            else
                calculatorScreen.Text += 9.ToString();
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            if (calculatorScreen.Text.Contains("="))
                calculatorScreen.Text = "+";
            else
                calculatorScreen.Text += '+';

            operands.Enqueue(number);
            number = 0;
            operators.Enqueue('+');
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            operands.Enqueue(number);
            number = 0;
            operators.Enqueue('-');
            calculatorScreen.Text += '-';
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            operands.Enqueue(number);
            number = 0;
            operators.Enqueue('*');
            calculatorScreen.Text += '*';
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            operands.Enqueue(number);
            number = 0;
            operators.Enqueue('/');
            calculatorScreen.Text += '/';
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            operands.Enqueue(number);
            number = 0;

            if (operands.Count > operators.Count)
                calculate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            operands.Clear();
            operators.Clear();
            number = 0;
            calculatorScreen.Text = 0.ToString();
        }

        public void callButton_Click(char buttonChar)
        {
            EventArgs args = null;

            switch(buttonChar)
            {
                case '1':
                    oneButton_Click('1', args);
                    break;
                case '2':
                    twoButton_Click('2', args);
                    break;
                case '3':
                    threeButton_Click('3', args);
                    break;
            }
        }

        private void calculate()
        {
            char op;
            int operand1, operand2;

            while (operators.Count > 0)
            {
                op = operators.Dequeue();
                operand2 = operands.Dequeue();
                operand1 = operands.Dequeue();

                switch (op)
                {
                    case '+':
                        number = operand1 + operand2;
                        break;
                    case '-':
                        number = operand1 - operand2;
                        break;
                    case '*':
                        number = operand1 * operand2;
                        break;
                    default:
                        number = operand1 / operand2;
                        break;
                }
                operands.Enqueue(number);
            }

            calculatorScreen.Text = "=" + number.ToString();
            number = 0;
        }
    }
}
