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
        private bool notesShown = false; //are the notes currently being shown
        private ApptBlockControl sourceApptBlock = null; //appointment block that was clicked to open this window
        private string apptStatus = null; //the status as a string (should be an enum but aint got time for that shit)

        private Appointment apptRepresenting = null; //the appointment this app window is showing
        
        //old constructor that is now depricated
        //i think history/future currently uses this but that should be changed
        /*
        public ApptWindow()
        {
            InitializeComponent();
            this.apptGrid.Height = 195;
            this.deleteButton.Margin = new Thickness(251.976, 158, 0, 0);

            this.billingButton.Click += BillingButton_Click;

            this.notArrivedRadio.IsChecked = true; //default radio button selection
            apptStatus = "Not Arrived";
        }
        */

        //initializes given a block that was clicked, and the appointment object that block contained
        //use this constructor if one of the coloured blocks was clicked to open this
        public ApptWindow(ApptBlockControl sourceApptBlock, Appointment sourceAppt)
        {
            InitializeComponent();
            this.sourceApptBlock = sourceApptBlock;

            loadAppointment(sourceAppt);

            this.apptGrid.Height = 195;
            this.deleteButton.Margin = new Thickness(251.976, 158, 0, 0);

            this.billingButton.Click += BillingButton_Click;

            MediSchedData.dbChanged += handleDbChange;
        }

        //initializes given only the appointment object that block contained
        //use this constructor if one of the history/future blocks was used to open this
        public ApptWindow(Appointment sourceAppt)
        {
            InitializeComponent();

            loadAppointment(sourceAppt);

            this.apptGrid.Height = 195;
            this.deleteButton.Margin = new Thickness(251.976, 158, 0, 0);

            this.billingButton.Click += BillingButton_Click;

            MediSchedData.dbChanged += handleDbChange;
        }

        //handles the database changing
        private void handleDbChange(object sender, EventArgs e)
        {
            if (this.apptRepresenting != null)
            {
                loadAppointment(this.apptRepresenting);
            }
            else
            {
                this.Close();
            }
        }

        //loads an appointment object's data to the window
        //only partially complete, just does the stuff Joel's stuff needs it to
        private void loadAppointment(Appointment sourceAppt)
        {
            this.apptRepresenting = sourceAppt;
            this.apptType.Text = this.apptRepresenting.getApptType();
            this.pnameButton.Content = this.apptRepresenting.getPatientName();
            this.apptStatus = this.apptRepresenting.getApptStatus();
            switch (this.apptStatus)
            {
                case "Not Arrived":
                    this.notArrivedRadio.IsChecked = true;
                    break;
                case "Waiting":
                    this.waitingRadio.IsChecked = true;
                    break;
                case "Being Seen":
                    this.beingSeenRadio.IsChecked = true;
                    break;
                case "Seen":
                    this.seenRadio.IsChecked = true;
                    break;
                case "Billed":
                    this.billedRadio.IsChecked = true;
                    break;
            }
        }

        //opens the billing for this appointment
        private void BillingButton_Click(object sender, RoutedEventArgs e)
        {
            BillingWindow billingWindow = new BillingWindow();
            billingWindow.Owner = this;
            billingWindow.Show();
        }

        //on window load event, not sure why this stuff isnt in the constructor, was still learning wpf
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            notesShown = false;
            this.apptGrid.Height = 195;
            this.addNotesButton.Content = "View Notes";
        }

        //Shows and saves/hides the notes section
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

        //event for when you click on the patient's name
        private void pnameButton_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo patientInfoWindow = new PatientInfo(this.apptRepresenting.getPatient());
            patientInfoWindow.Owner = this;
            patientInfoWindow.Show();
        }

        //event for clicking the delete button (currently does nothing)
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            //delete the appointment
            this.Close();
            MediSchedData.deleteAppointment(this.apptRepresenting);
        }

        //event for changing the status of the appointment
        private void radio_Click(object sender, RoutedEventArgs e)
        {
            if(notArrivedRadio.IsChecked == true)
            {
                this.apptStatus = "Not Arrived";
            }
            else if(waitingRadio.IsChecked == true)
            {
                this.apptStatus = "Waiting";
            }
            if (beingSeenRadio.IsChecked == true)
            {
                this.apptStatus = "Being Seen";
            }
            else if (seenRadio.IsChecked == true)
            {
                this.apptStatus = "Seen";
            }
            if (billedRadio.IsChecked == true)
            {
                this.apptStatus = "Billed";
            }

            if (sourceApptBlock != null)
            {
                sourceApptBlock.setApptStatus(this.apptStatus);
            }
            if (apptRepresenting != null)
            {
                apptRepresenting.setApptStatus(this.apptStatus);
            }
        }
    }
}
