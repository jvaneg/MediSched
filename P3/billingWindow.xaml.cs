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
        private Appointment aptBilling;

        public BillingWindow(string patientName, string apptType, Appointment billingInfo)
        {
            InitializeComponent();

            BillingWindow.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            newWindowOpened(this, null);

            this.patientInformationTextbox.Text = "Patient: " + patientName + "\r\nAppointment Type: " + apptType;
            aptBilling = billingInfo;

            List<Billing> ls = aptBilling.getbillingInfoList();
            if(ls.Count > 0)
            {
                for(int i=0; i < ls.Count; i++)
                {
                    descriptCostDataGrid.Items.Add(ls[i]);
                }
            }


            this.addToTableButton.Click += AddToTableButton_Click;
            this.printButton.Click += PrintButton_Click;
            this.OKButton.Click += OKButton_Click;

        }

        private void AddToTableButton_Click(object sender, RoutedEventArgs e)
        {


            decimal d;
            if (decimal.TryParse(itemCostTextBox.Text, out d))
            {
                Billing billingObj = new Billing() { Description = itemDescriptionTextBox.Text, Cost = itemCostTextBox.Text };
                descriptCostDataGrid.Items.Add(billingObj);

                aptBilling.addBillingInfoList(billingObj);

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
                Billing deletedObj = (Billing) descriptCostDataGrid.SelectedItem;

                aptBilling.deleteBillingRow(deletedObj);

                descriptCostDataGrid.Items.Remove(deletedObj);
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

        //handles when the main window closes, closes this window
        private void handleMainClose(object sender, EventArgs e)
        {
            this.Close();
        }

        //handles a new billing window being opened
        //if a new window of this type opens, closes the others
        private void handleNewWindow(object sender, EventArgs e)
        {
            if ((sender as BillingWindow) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            BillingWindow.newWindowOpened -= handleNewWindow;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };
    }
}
