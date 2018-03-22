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
    /// Interaction logic for ApptWindow.xaml
    /// </summary>
    public partial class ApptWindow : Window
    {
        private bool notesShown = false;
        

        public ApptWindow()
        {
            InitializeComponent();
            this.apptGrid.Height = 195;
            this.deleteButton.Margin = new Thickness(251.976, 158, 0, 0);

            this.billingButton.Click += BillingButton_Click;

            this.notArrivedRadio.IsChecked = true; //default radio button selection
        }

        private void BillingButton_Click(object sender, RoutedEventArgs e)
        {
            billingWindow billingWindow = new billingWindow();
            billingWindow.Owner = this;
            billingWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notesShown = false;
            this.apptGrid.Height = 195;
            this.addNotesButton.Content = "View Notes";
        }

        //Shows and hides the notes section
        private void addNotesButton_Click(object sender, RoutedEventArgs e)
        {
            if (!notesShown)
            {
                this.apptGrid.Height = 408;
                this.deleteButton.Margin = new Thickness(251.976, 375, 0, 0);
                this.addNotesButton.Content = "Save Notes";
                notesShown = true;
            }
            else
            {
                this.apptGrid.Height = 195;
                this.deleteButton.Margin = new Thickness(251.976, 158, 0, 0);
                this.addNotesButton.Content = "View Notes";
                notesShown = false;
            }
        }

        private void pnameButton_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo patientInfoWindow = new PatientInfo();
            patientInfoWindow.Owner = this;
            patientInfoWindow.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //delete the appointment
            this.Close();
        }

    }
}
