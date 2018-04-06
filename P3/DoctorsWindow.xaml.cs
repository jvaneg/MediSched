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
        //DataTable dt = new DataTable();

        public DoctorsWindow()
        {
            InitializeComponent();

            //load data
            List<Doctor> ls;
            if((ls = MediSchedData.getDocList()).Count > 0)
            {

                for (int i = 0; i < ls.Count; i++)
                {
                    //docListGrid.Items.Add(new Doctor() {ID = ls[i].ID, Name = ls[i].Name, Days = ls[i].Days, Hours = ls[i].Hours });
                    docListGrid.Items.Add(ls[i]);
                }
            }

            //docListGrid.Items.Add(new Doctor() { Name = "Arshe D", Days = "MTWR", Hours = "8:00-20:30" });
            //docListGrid.Items.Add(new Doctor() { Name = "Philli P", Days = "W", Hours = "1:00-10:00" });
        }

       

        private void addDoctorButton_Click(object sender, RoutedEventArgs e)
         {

             NewDoctorWindow newDocWindow = new NewDoctorWindow(false);  //false-> clear edit mode
             newDocWindow.Owner = this;
             newDocWindow.Show();
         }

        private void editDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (docListGrid.SelectedItem != null)
            {
                Doctor doc = (Doctor)docListGrid.SelectedItem;
                NewDoctorWindow newDocWindow = new NewDoctorWindow(doc.Name, doc.Days, doc.Hours, true); //true -> set edit mode
                newDocWindow.Owner = this;
                newDocWindow.Show();

            }
        }

        private void deleteDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (docListGrid.SelectedItem != null)
            {
                MediSchedData.deleteDoc((docListGrid.SelectedItem as Doctor).ID);
                docListGrid.Items.Remove(docListGrid.SelectedItem);
            }
        }
    }
}
