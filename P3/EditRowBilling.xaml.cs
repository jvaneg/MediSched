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

namespace P3
{
    /// <summary>
    /// Interaction logic for EditRowBilling.xaml
    /// </summary>
    public partial class EditRowBilling : Window
    {

        public EditRowBilling()
        {
            EditRowBilling.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            EditRowBilling.newWindowOpened(this, null);

            InitializeComponent();            
        }

        public EditRowBilling(string description, string cost)
        {
            EditRowBilling.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            EditRowBilling.newWindowOpened(this, null);

            InitializeComponent();
            this.editButton.Click += EditButton_Click;
        }

        //handles when the main window closes, closes this window
        private void handleMainClose(object sender, EventArgs e)
        {
            this.Close();
        }

        //handles a new appt window being opened
        //if a new window of this type opens, closes the others
        private void handleNewWindow(object sender, EventArgs e)
        {
            if ((sender as EditRowBilling) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            EditRowBilling.newWindowOpened -= handleNewWindow;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            BillingWindow parentWindow = (BillingWindow)this.Owner;
            decimal d;
            Billing rowToBeUpdated = (Billing)parentWindow.descriptCostDataGrid.SelectedItem;
            if (decimal.TryParse(editCostTextbox.Text, out d))
            {

                rowToBeUpdated.Description = editDescriptionTextbox.Text;
                rowToBeUpdated.Cost = editCostTextbox.Text;
                parentWindow.descriptCostDataGrid.Items.Refresh();

                this.Close();
            }
            else
            {
                MessageBox.Show("Inavlid Numbers entered for cost, please try again");
            }
        }


    }
}
