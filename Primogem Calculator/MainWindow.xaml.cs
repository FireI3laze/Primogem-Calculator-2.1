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

namespace Primogem_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Answer.Visibility = Visibility.Hidden;
        }

        bool DisclaimerVisibility = false;

        private void WishesInTime(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();

            Solution.Content = "";
            window2.ShowDialog();
        }
        private void DoIHaveToPay(object sender, RoutedEventArgs e)
        {
            Solution.Content = "Too much. (Coming soon)";
        }
        private void Placeholder(object sender, RoutedEventArgs e)
        {
            Solution.Content = "Too much. (Coming soon)";
        }

        /*private void Disclaimer(object sender, RoutedEventArgs e)
        {
            if (DisclaimerVisibility)
            {
                Answer.Visibility = Visibility.Hidden;
                DisclaimerVisibility = false;
            }
            else
            {
                Answer.Visibility = Visibility.Visible;
                DisclaimerVisibility = true;
            }
        }
        */
    }
}
