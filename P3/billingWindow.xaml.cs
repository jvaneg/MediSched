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
        decimal totalCost = 0;

        public billingWindow()
        {
            InitializeComponent();

            this.addToTableButton.Click += AddToTableButton_Click;
            this.printButton.Click += PrintButton_Click;
            this.OKButton.Click += OKButton_Click;
            this.addNewItemButton.Click += AddNewItemButton_Click;


            

        }

        private void AddToTableButton_Click(object sender, RoutedEventArgs e)
        {

            decimal d;
            if (decimal.TryParse(itemCostTextBox.Text, out d))
            {
                this.itemDescriptionTextBox.Visibility = Visibility.Hidden;
                this.itemCostTextBox.Visibility = Visibility.Hidden;
                this.descriptionLabel.Visibility = Visibility.Hidden;
                this.costLabel.Visibility = Visibility.Hidden;
                this.addItemLabel.Visibility = Visibility.Hidden;
                this.addCostLabel.Visibility = Visibility.Hidden;

                totalCost += (Convert.ToDecimal(itemCostTextBox.Text));
                this.totalLabel.Text = "Total: " + totalCost;


                itemCostTextBox.Text = "0";
            }
            else
            {
                MessageBox.Show("Inavlid Numbers entered for cost, please try again");
            }
        }

        private void AddNewItemButton_Click(object sender, RoutedEventArgs e)
        {

            fillingDataGridUsingDataTab1();


            this.costLabel.Visibility = Visibility.Hidden;
            this.addItemLabel.Visibility = Visibility.Hidden;
            this.addCostLabel.Visibility = Visibility.Hidden;

            this.addToTableButton.Visibility = Visibility.Visible;
            this.OKButton.Visibility = Visibility.Visible;
            this.printButton.Visibility = Visibility.Visible;

            this.scrollViewerBilling.Visibility = Visibility.Visible;
            this.descriptCostDataGrid.Visibility = Visibility.Visible;
        }

        void fillingDataGridUsingDataTab1() {

            DataTable dt = new DataTable();
            DataColumn description = new DataColumn("description", typeof(string));
            DataColumn cost = new DataColumn("cost", typeof(decimal));

            dt.Columns.Add(description);
            dt.Columns.Add(cost);

            DataRow addRow = dt.NewRow();
            addRow["description"] = itemDescriptionTextBox.Text;
            addRow["Cost"] = itemCostTextBox.Text;
            dt.Rows.Add(addRow);

            descriptCostDataGrid.ItemsSource = dt.DefaultView;
                       
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
