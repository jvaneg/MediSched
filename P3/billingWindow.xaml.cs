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
using System.Data;

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

            this.addToTableButton.Click += AddToTableButton_Click;
            this.printButton.Click += PrintButton_Click;
            this.OKButton.Click += OKButton_Click;
            this.resetTableButton.Click += ResetTableButton_Click;

        }

        private void ResetTableButton_Click(object sender, RoutedEventArgs e)
        {
            descriptCostDataGrid.Items.Clear();
            descriptCostDataGrid.Items.Refresh();
        }

        private void AddToTableButton_Click(object sender, RoutedEventArgs e)
        {

            decimal d;
            if (decimal.TryParse(itemCostTextBox.Text, out d))
            {
                this.itemDescriptionTextBox.Visibility = Visibility.Visible;
                this.itemCostTextBox.Visibility = Visibility.Visible;
                this.descriptionLabel.Visibility = Visibility.Visible;
                this.costLabel.Visibility = Visibility.Visible;
                this.addItemLabel.Visibility = Visibility.Visible;
                this.addCostLabel.Visibility = Visibility.Visible;

                descriptCostDataGrid.Items.Add(new { Description = itemDescriptionTextBox.Text, Cost = itemCostTextBox.Text });

            }
            else
            {
                MessageBox.Show("Inavlid Numbers entered for cost, please try again");
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sent to printer");
        }
    }
}
