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
    /// Interaction logic for NewApptWindow.xaml
    /// </summary>
    public partial class NewApptWindow : Window
    {
        public NewApptWindow()
        {
            InitializeComponent();
        }

        private void txtNameToSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtNameToSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void NewPatient_Click(object sender, RoutedEventArgs e)
        {
            NewPatientsWindow patientWindow = new NewPatientsWindow(true);
            patientWindow.Owner = this.Owner;
            patientWindow.Show();
            this.Close();
        }

        //currently just creates a patient
        //placeholder
        private void Patient_Selected(object sender, RoutedEventArgs e)
        {
            //somehow get the patient object from the selected item
            Patient selectedPatient = new Patient(1); //placeholder
            NewApptMonth apptMonthWindow = new NewApptMonth(selectedPatient);
            apptMonthWindow.Owner = this.Owner;
            apptMonthWindow.Show();
            this.Close();
        }
    }
}
