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
        public PatientsWindow()
        {
            InitializeComponent();
            this.Loaded += Window_Loaded;
        }

        //stuff for the actual search that is currently nonfunctional lmao
        ObservableCollection<Patient> patientList = new ObservableCollection<Patient>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            patientList.Add(new Patient(1)); //placeholder
            patientList.Add(new Patient(2)); //placeholder
            patientList.Add(new Patient(3)); //placeholder

            /*
            patientList.Add(new Patient() { PatientNo = 1001, PatientName = "Mahesh" });
            patientList.Add(new Patient() { PatientNo = 1002, PatientName = "Amit" });
            patientList.Add(new Patient() { PatientNo = 1003, PatientName = "Vaibhav" });
            patientList.Add(new Patient() { PatientNo = 1004, PatientName = "Ashwin" });
            patientList.Add(new Patient() { PatientNo = 1005, PatientName = "Prashant" });
            patientList.Add(new Patient() { PatientNo = 1006, PatientName = "Vinit" });
            patientList.Add(new Patient() { PatientNo = 1007, PatientName = "Abhijit" });
            patientList.Add(new Patient() { PatientNo = 1008, PatientName = "Pankaj" });
            patientList.Add(new Patient() { PatientNo = 1009, PatientName = "Kaustubh" });
            patientList.Add(new Patient() { PatientNo = 1010, PatientName = "Mohan" });
            */


            lstPatientData.ItemsSource = patientList;

        }

        private void txtNameToSearch_TextChanged(object sender,TextChangedEventArgs e)
        {
            /*
             *    string txtOrig = txtNameToSearch.Text;
               string upper = txtOrig.ToUpper();
               string lower = txtOrig.ToLower();

               var patientFiltered = from Patient in patientList let ename = Patient.PatientName
                                 where ename.StartsWith(lower) || ename.StartsWith(upper) || ename.Contains(txtOrig)
                                 select Patient;

               lstPatientData.ItemsSource = patientFiltered;

           */
            string txtOrig = txtNameToSearch.Text;
            string upper = txtOrig.ToUpper();
            string lower = txtOrig.ToLower();


            List<Patient> filteredPatients = this.patientList.Where(p => p.PatientName.Contains(txtOrig)).ToList();

            Console.WriteLine(filteredPatients);

            var patientFiltered = from Patient in patientList
                                  let pname = Patient.PatientName
                                  where
                                  pname.StartsWith(lower)
                                  || pname.StartsWith(upper)
                                  || pname.Contains(txtOrig)
                                  select Patient;

            lstPatientData.ItemsSource = patientFiltered;

        }


        //select a patient from the list
        //currently generates a placeholder patient
        private void Patient_Selected(object sender, RoutedEventArgs e)
        {
            //somehow get the patient object from the selected item
            Patient selectedPatient = new Patient(1); //placeholder
            PatientInfo patientinfo = new PatientInfo(selectedPatient);
            patientinfo.Owner = this.Owner;
            this.Close();
            patientinfo.Show();
        }

        private void GetIndex0(object sender, RoutedEventArgs e)
        {
            /*
            ListBoxItem lbi = (ListBoxItem)
                (lstPatientData.ItemContainerGenerator.ContainerFromIndex(0));
            Item.Content = "The contents of the item at index 0 are: " + 
                (lbi.Content.ToString()) + ".";
            */
            
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
