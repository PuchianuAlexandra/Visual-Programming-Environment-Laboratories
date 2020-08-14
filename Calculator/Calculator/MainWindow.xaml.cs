using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }


        private void executeButton(int nr)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 = (number1 * 10) + nr;
                txtDisplay.Text = number1.ToString();
                lblEcuation.Content = number1.ToString();
                return;
            }
            else
            {
                number2 = (number2 * 10) + nr;
                txtDisplay.Text = number2.ToString();
                lblEcuation.Content = number1.ToString()+ operation + number2.ToString();
                return;
            }
        }
              
        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            executeButton(0);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            executeButton(1);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            executeButton(2);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            executeButton(3);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            executeButton(4);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            executeButton(5);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            executeButton(6);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            executeButton(7);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            executeButton(8);
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            executeButton(9);
        }

        private void changeOperation(string opr)
        {
            operation = opr;
            txtDisplay.Text = "0";
            lblEcuation.Content = lblEcuation.Content + opr;
            return; 
        }
      
        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            changeOperation("+");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            changeOperation("-");
        }

        private void btnTimes_Click(object sender, RoutedEventArgs e)
        {
            changeOperation("*");
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            changeOperation("/");
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            switch (operation)
            {
                case "+":
                    txtDisplay.Text = (number1 + number2).ToString();
                    number1 = number1 + number2;
                    break;
                case "-":
                    txtDisplay.Text = (number1 - number2).ToString();
                    number1 = number1 - number2;
                    break;
                case "*":
                    txtDisplay.Text = (number1 * number2).ToString();
                    number1 = number1 * number2;
                    break;
                case "/":
                    if(number2 == 0)
                    {
                        txtDisplay.Text = "Cannot divide by zero!";
                        break;
                    }
                    txtDisplay.Text = (number1 / number2).ToString();
                    number1 = number1 / number2;
                    break;
            }
            lblEcuation.Content = lblEcuation.Content + "=" + number1;
            number2 = 0;

        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 = 0;
                lblEcuation.Content = "0";
            }
            else
            {
                number2 = 0;
                lblEcuation.Content = number1.ToString() + operation;
            }

            txtDisplay.Text = "0";
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            txtDisplay.Text = "0";
            lblEcuation.Content = "0";
        }

        private void btnBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 = (number1 / 10);
                txtDisplay.Text = number1.ToString();
                lblEcuation.Content = number1.ToString();
            }
            else
            {
                number2 = (number2 / 10);
                txtDisplay.Text = number2.ToString();
                lblEcuation.Content = number1.ToString() + operation + number2.ToString();
            }
        }

        private void btnPositiveNegative_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(operation))
            {
                number1 *= -1;
                txtDisplay.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                txtDisplay.Text = number2.ToString();
            }
        }

        long number1 = 0;
        long number2 = 0;
        string operation = "";
    }
}
