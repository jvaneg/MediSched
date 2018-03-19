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
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace P3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class billingWindow : Window
    {
        public billingWindow()
        {
            InitializeComponent();

            this.editCostButton.Visibility = Visibility.Hidden;

            this.saveCostButton.Click += SaveCostButton_Click;
            this.printButton.Click += PrintButton_Click;
            this.OKButton.Click += OKButton_Click;
            this.editCostButton.Click += EditCostButton_Click;


        }

        private void EditCostButton_Click(object sender, RoutedEventArgs e)
        {
            this.editCostButton.Visibility = Visibility.Hidden;

            itemOneTextBox.Visibility = Visibility.Visible;
            itemTwoTextBox.Visibility = Visibility.Visible;
            itemOtherTextBox.Visibility = Visibility.Visible;

        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sent to printer");
        }

        private void SaveCostButton_Click(object sender, RoutedEventArgs e)
        {

            decimal totalCost;
            decimal d;
            if ((decimal.TryParse(itemOneTextBox.Text, out d)) && (decimal.TryParse(itemTwoTextBox.Text, out d)) && decimal.TryParse(itemOtherTextBox.Text, out d))
            {
                itemOneTextBox.Visibility = Visibility.Hidden;
                itemTwoTextBox.Visibility = Visibility.Hidden;
                itemOtherTextBox.Visibility = Visibility.Hidden;

                totalCost = (Convert.ToDecimal(itemOneTextBox.Text)) + (Convert.ToDecimal(itemTwoTextBox.Text)) + (Convert.ToDecimal(itemOtherTextBox.Text));

                this.totalLabel.Text = "Total: " + totalCost;

                this.editCostButton.Visibility = Visibility.Visible;

            }
            else
            {
                MessageBox.Show("Inavlid Numbers entered for cost, please try again");
            }


        }
    }
}
