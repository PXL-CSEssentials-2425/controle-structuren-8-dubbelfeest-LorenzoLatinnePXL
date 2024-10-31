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

namespace Dubbelfeest
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

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            peopleTextBox.Clear();
            resultTextBox.Clear();
            peopleTextBox.Focus();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            resultTextBox.Foreground = Brushes.Black;
            double chanceOfSameDay = 1;
            double daysInYear = 365;
            bool isValidAmountOfPeople = int.TryParse(peopleTextBox.Text, out int amountOfPeople);

            if (!isValidAmountOfPeople)
            {
                resultTextBox.Text = "Ongeldig aantal personen.";
                resultTextBox.Foreground = Brushes.Red;
            } else
            {
                resultTextBox.Clear();

                if (amountOfPeople > 1) 
                {
                    resultTextBox.Clear();

                    for (int i = amountOfPeople; i > 1; i--)
                    {
                        daysInYear--;
                        chanceOfSameDay *= daysInYear / 365;
                    }

                    chanceOfSameDay = (1 - chanceOfSameDay) * 100;

                    resultTextBox.Text = $"De kans op gelijke verjaardagen is {chanceOfSameDay:N2}%.";
                }
                else if (amountOfPeople == 1)
                {
                    resultTextBox.Text = "Indien er maar 1 persoon is, is de kans op een dubbelfeest 0.";
                }
                else
                {
                    resultTextBox.Text = "Bij 0 personen is er geen feest.";
                }

            }
        }
    }
}
