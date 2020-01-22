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

namespace MyFirstApp
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

        private void buttonOperator_Click(object sender, RoutedEventArgs e)
        {
            Button operationButton = sender as Button;
            string operation = operationButton.Name;

            double.TryParse(operand1.Text, out double operand1Num);
            double.TryParse(operand2.Text, out double operand2Num);

            switch (operation)
            {
                case "buttonAdd":
                    answer.Text = (operand1Num + operand2Num).ToString();
                    break;
                case "buttonSub":
                    answer.Text = (operand1Num - operand2Num).ToString();
                    break;
                case "buttonMult":
                    answer.Text = (operand1Num * operand2Num).ToString();
                    break;
                case "buttonDiv":
                    if (operand2Num == 0)
                    {
                        ErrorWindow errorWindow = new ErrorWindow();

                        errorWindow.ShowDialog();

                        operand2.Text = "";
                        operand2.Focus();
                    }
                    else
                    {
                        answer.Text = (operand1Num / operand2Num).ToString();
                    }
                    break;
                default:
                    break;
            }  
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            Help helpWindow = new Help();

            helpWindow.Show();
        }

        private void operand1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(operand1.Text, out double number))
            {
                textBlockUserFeedback.Text = "Operands must be numbers";
            }
            else
            {
                textBlockUserFeedback.Text = "";
            }
        }

        private void operand2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!double.TryParse(operand2.Text, out double number))
            {
                textBlockUserFeedback.Text = "Operands must be numbers";
            }
            else
            {
                textBlockUserFeedback.Text = "";
            }
        }

        private void Feet_Checked(object sender, RoutedEventArgs e)
        {
            Length.Content = "Length (ft)";
            Width.Content = "Width (ft)";
            Result.Content = "sq ft";
            Conversion.Content = "Convert to feet";
        }

        private void Meters_Checked(object sender, RoutedEventArgs e)
        {
            Length.Content = "Length (m)";
            Width.Content = "Width (m)";
            Result.Content = "sq m";
            Conversion.Content = "Convert to meters";
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            operand1.Text = "";
            operand2.Text = "";
            answer.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }


    }
}
