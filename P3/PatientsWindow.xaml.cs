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
using System.Collections.ObjectModel;
namespace P3
{
    /// <summary>
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientsWindow : Window
    {
        private ObservableCollection<Patient> patientList { get; set; } //dont understand how binding works but if this is gone it stops working

        public PatientsWindow()
        {
            patientList = new ObservableCollection<Patient>();

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


        //select a patient from the list
        private void Patient_Selected(object sender, RoutedEventArgs e)
        {
            //somehow get the patient object from the selected item
            Patient selectedPatient = ((sender as ListBox).SelectedItem as Patient); //placeholder
            if (selectedPatient != null)
            {
                PatientInfo patientinfo = new PatientInfo(selectedPatient);
                patientinfo.Owner = this.Owner;
                this.Close();
                patientinfo.Show();
            }
        }

        //click new patient
        private void NewPatient_Click(object sender, RoutedEventArgs e)
        {
            NewPatientsWindow patientWindow = new NewPatientsWindow(false);
            patientWindow.Owner = this.Owner;
            this.Close();
            patientWindow.Show();
        }

    }
}
