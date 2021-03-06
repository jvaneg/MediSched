﻿using System;
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

        //initializes given a block that was clicked, and the appointment object that block contained
        //use this constructor if one of the coloured blocks was clicked to open this
        public ApptWindow(ApptBlockControl sourceApptBlock, Appointment sourceAppt)
        {
            InitializeComponent();
            this.sourceApptBlock = sourceApptBlock;

            MainWindow.mainClosed += handleMainClose;
            ApptWindow.newWindowOpened += handleNewWindow;
            newWindowOpened(this, null);

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

            MainWindow.mainClosed += handleMainClose;
            ApptWindow.newWindowOpened += handleNewWindow;
            newWindowOpened(this, null);

            loadAppointment(sourceAppt);

            this.apptGrid.Height = 195;
            this.deleteButton.Margin = new Thickness(251.976, 158, 0, 0);

            this.billingButton.Click += BillingButton_Click;

            MediSchedData.dbChanged += handleDbChange;
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
            if ((sender as ApptWindow) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            ApptWindow.newWindowOpened -= handleNewWindow;
            MediSchedData.dbChanged -= handleDbChange;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };

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

            int startBlock = this.apptRepresenting.getStartBlock();
            int blockDuration = this.apptRepresenting.getApptBlockLength();

            this.apptTime.Text = this.apptRepresenting.apptBlockFormatting(startBlock) + " - " + this.apptRepresenting.apptBlockFormatting(startBlock + blockDuration);
            this.apptType.Text = this.apptRepresenting.getApptType();
            this.pnameButton.Content = this.apptRepresenting.getPatientName();
            this.apptStatus = this.apptRepresenting.getApptStatus();
            this.noteText.Text = this.apptRepresenting.getNotes();
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
            BillingWindow billingWindow = new BillingWindow(this.apptRepresenting.getPatientName(), this.apptRepresenting.getApptType(), this.apptRepresenting);
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

                //save the notes
                this.apptRepresenting.setNotes(this.noteText.Text);
            }
        }

        //event for when you click on the patient's name
        private void pnameButton_Click(object sender, RoutedEventArgs e)
        {
            PatientInfo patientInfoWindow = new PatientInfo(this.apptRepresenting.getPatient());
            //patientInfoWindow.Owner = this; //TODO fix this owner mess
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
