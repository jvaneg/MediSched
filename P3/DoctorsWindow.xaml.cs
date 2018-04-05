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

using System.Data;
using System.Collections.ObjectModel;

namespace P3
{
    /// <summary>
    /// Interaction logic for NewDoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        DataTable dt = new DataTable();

        ObservableCollection<Doctor> dc = new ObservableCollection<Doctor>();
        public DoctorsWindow()
        {
            InitializeComponent();
            //docListGrid.ItemsSource = Doctor.getDoctor();
            docListGrid.Items.Add(new Doctor() { Name = "Arshe D", Days = "MTWR", Hours = "8:00-20:30" });
            docListGrid.Items.Add(new Doctor() { Name = "Philli P", Days = "W", Hours = "1:00-10:00" });
        }
                

        private void addDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            
            NewDoctorWindow newDocWindow = new NewDoctorWindow(false);  //false-> clear edit mode

            //WHEN YOU CREATE A NEW WINDOW SET THE OWNERSHIP OF THE CHILD
            newDocWindow.Owner = this;
            newDocWindow.Show();
        }

       
        private void editDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (docListGrid.SelectedItem != null)
            {
                Doctor doc = (Doctor)docListGrid.SelectedItem;
                /*
                string docName = doc.Name;
                string docWorkingDays = doc.Days;
                string docWorkingHours = doc.Hours;
                */

                NewDoctorWindow newDocWindow = new NewDoctorWindow(doc.Name, doc.Days, doc.Hours, true); //true -> set edit mode
                newDocWindow.Owner = this;
                newDocWindow.Show();
            }
        }

        private void deleteDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (docListGrid.SelectedItem != null)
            {
                docListGrid.Items.Remove((Doctor)docListGrid.SelectedItem);
            }
        }
    }
}
