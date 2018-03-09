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

namespace PWDChecker
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

        private void pwdBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //password has changed, get statistics from current password
            int[] statistics = new int[5];
            //char count
            statistics[0] = pwdBox.Password.Length;
            //caps
            statistics[1] = pwdBox.Password.Count(char.IsUpper);
            //lowercase
            statistics[2] = pwdBox.Password.Count(char.IsLower);
            //numbers
            statistics[3] = pwdBox.Password.Count(char.IsNumber);
            //all the rest are special characters
            statistics[4] = pwdBox.Password.Length - (statistics[1] + statistics[2] + statistics[3]);

            //update the UI
            charCount.Text = "Character count: " + statistics[0].ToString();
            capitalCount.Text = "Capital letter count: " + statistics[1].ToString();
            lowerCount.Text = "Lowercase letter count: " + statistics[2].ToString();
            numbCount.Text = "Number count: " + statistics[3].ToString();
            specialCount.Text = "Special character count: " + statistics[4].ToString();

            int categoryCount = 0;
            for (int i = 1; i<5; i++)
            {
                if(statistics[i] > 0)
                {
                    categoryCount++;
                }
            }
            if (statistics[0] > 15 && categoryCount > 3)
            {
                // good pwd
                checkMessage.Content = "Good";
                checkMessage.Background = new SolidColorBrush(Colors.Green);
            }
            else if (statistics[0] > 12 && categoryCount > 2)
            {
                // moderate pwd
                checkMessage.Content = "Moderate";
                checkMessage.Background = new SolidColorBrush(Colors.LightGreen);
            }
            else if (statistics[0] > 8 && categoryCount > 1)
            {
                // fair pwd
                checkMessage.Content = "Fair";
                checkMessage.Background = new SolidColorBrush(Colors.Yellow);
            }
            else
            {
                //poor pwd
                checkMessage.Content = "Poor";
                checkMessage.Background = new SolidColorBrush(Colors.OrangeRed);
            }
        }
    }
}
