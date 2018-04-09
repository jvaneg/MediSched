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

using System.Collections.ObjectModel;

namespace P3
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BillingWindow : Window
    {



        public BillingWindow(string patientName, string apptType)
        {
            InitializeComponent();

            this.patientInformationTextbox.Text = "Patient: " + patientName + "\r\nAppointment Type: " + apptType;

            this.addToTableButton.Click += AddToTableButton_Click;
            this.printButton.Click += PrintButton_Click;
            this.OKButton.Click += OKButton_Click;

        }

        private void AddToTableButton_Click(object sender, RoutedEventArgs e)
        {

            decimal d;
            if (decimal.TryParse(itemCostTextBox.Text, out d))
            {
                descriptCostDataGrid.Items.Add(new Billing(){ Description = itemDescriptionTextBox.Text, Cost = itemCostTextBox.Text });
            }
            else
            {
                MessageBox.Show("Inavlid Numbers entered for cost, please try again");
            }
        }

        private void editBillingButton_Click(object sender, RoutedEventArgs e)
        {

            if (descriptCostDataGrid.SelectedItem != null)
            {
                Billing editBilling = (Billing)descriptCostDataGrid.SelectedItem;

                EditRowBilling editBillingWindow = new EditRowBilling(editBilling.Description, editBilling.Cost);
                editBillingWindow.Owner = this;
                editBillingWindow.Show();
            }
        }

        private void deleteBillingButton_Click(object sender, RoutedEventArgs e)
        {
            if (descriptCostDataGrid.SelectedItem != null)
            {
                descriptCostDataGrid.Items.Remove((Billing)descriptCostDataGrid.SelectedItem);
            }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {

            List<Billing> savedBilling = new List<Billing>();

            foreach(DataRowView dr in descriptCostDataGrid.ItemsSource)
            {
                
            }

            this.Close();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sent to printer");
        }
    }
}
