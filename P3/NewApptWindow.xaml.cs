using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NewApptWindow.xaml
    /// </summary>
    public partial class NewApptWindow : Window
    {
        private ObservableCollection<Patient> patientList { get; set; } //dont understand how binding works but if this is gone it stops working

        public NewApptWindow()
        {
            patientList = new ObservableCollection<Patient>();

            NewApptWindow.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            NewApptWindow.newWindowOpened(this, null);

            InitializeComponent();

            this.PatientList.SelectionChanged += Patient_Selected;

            loadPatients();
        }

        //loads patients into the box
        private void loadPatients()
        {
            this.PatientList.Items.Clear();

            foreach (Patient patient in MediSchedData.getPatientList())
            {
                this.PatientList.Items.Add(patient);
            }
        }

        //searches patients
        private void searchText(object sender, TextChangedEventArgs e)
        {
            string searchText = txtNameToSearch.Text;

            this.PatientList.Items.Clear();

            foreach (Patient patient in MediSchedData.getPatientList())
            {
                if (patient.PatientName.ToLower().Contains(searchText.ToLower()))
                {
                    this.PatientList.Items.Add(patient);
                }
            }
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
            if ((sender as NewApptWindow) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            NewApptWindow.newWindowOpened -= handleNewWindow;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };


        private void NewPatient_Click(object sender, RoutedEventArgs e)
        {
            NewPatientsWindow patientWindow = new NewPatientsWindow(true);
            //patientWindow.Owner = this.Owner; //TODO not sure if i should do this owner stuff
            patientWindow.Show();
            this.Close();
        }

        //currently just creates a patient
        private void Patient_Selected(object sender, RoutedEventArgs e)
        {
            //somehow get the patient object from the selected item
            Patient selectedPatient = ((sender as ListBox).SelectedItem as Patient); //placeholder
            if (selectedPatient != null)
            {
                NewApptMonth apptMonthWindow = new NewApptMonth(selectedPatient);
                //apptMonthWindow.Owner = this.Owner; //TODO not sure if i should do this owner stuff
                apptMonthWindow.Show();
                this.Close();
            }
        }
    }
}
