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

            if (Shape.SelectedIndex == 0)
            {
                answer.Text = (operand1Num * operand2Num).ToString();
            }
            else if (Shape.SelectedIndex == 1)
            {
                answer.Text = ((operand1Num * operand2Num) / 2).ToString();
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
            Conversion.Content = "Convert to meters";
        }

        private void Meters_Checked(object sender, RoutedEventArgs e)
        {
            Length.Content = "Length (m)";
            Width.Content = "Width (m)";
            Result.Content = "sq m";
            Conversion.Content = "Convert to feet";
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            operand1.Text = "";
            operand2.Text = "";
            answer.Text = "";
            convertValue.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Feet.IsChecked == true)
            {
                convertValue.Visibility = Visibility.Visible;
                Converted.Content = "sq m";
                double.TryParse(answer.Text, out double toMeters);
                convertValue.Text = Convert.ToString(toMeters / 3.281);
            }
            else
            {
                convertValue.Visibility = Visibility.Visible;

                Converted.Content = "sq ft";
                double.TryParse(answer.Text, out double toFeet);
                convertValue.Text = Convert.ToString(toFeet * 3.281);
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Feet.IsChecked = true;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
