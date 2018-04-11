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
            InitializeComponent();            
        }

        public EditRowBilling(string description, string cost)
        {
            InitializeComponent();
            this.editButton.Click += EditButton_Click;
        }

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
