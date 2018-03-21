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
namespace P3
{
    /// <summary>
    /// Interaction logic for NewDoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        DataTable dt = new DataTable();
        public DoctorsWindow()
        {
            InitializeComponent();

            //Binding the DataGrid to Doctor
            //DataContext = Doctor.getDoctor();

            docListGrid.ItemsSource = Doctor.getDoctor();
        }

        /*
        void fillingDataGridUsingDataTable()
        {
            

            DataColumn docName = new DataColumn("Name",typeof(string));
            DataColumn docWorkingDays = new DataColumn("Days", typeof(string));
            DataColumn docWorkingHours = new DataColumn("Hours", typeof(string));

            dt.Columns.Add(docName);
            dt.Columns.Add(docWorkingDays);
            dt.Columns.Add(docWorkingHours);

            DataRow firstR = dt.NewRow();
            firstR[0] = "Arsh";
            firstR[1] = "MTRF";
            firstR[2] = "12:00-20:00";

            dt.Rows.Add(firstR);
            docListGrid.ItemsSource = dt.DefaultView;
               
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           this.fillingDataGridUsingDataTable();
        }
        */

        private void addDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            NewDoctorWindow newDocWindow = new NewDoctorWindow();
            newDocWindow.Show();
        }

        /*
        private void doctorGrid_MouseEnter(object sender, MouseEventArgs e)
        {
            docListGrid.IsReadOnly = false;
            docListGrid.BeginEdit();
        }
        */


        private void editDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            Doctor doc = docListGrid.SelectedItem as Doctor;
            string docName = doc.Name;
            string docWorkingDays = doc.Days;
            string docWorkingHours = doc.Hours;            

           // MessageBox.Show("Should see: " + docName + " " + docWorkingDays + " " + docWorkingHours);

            NewDoctorWindow newDocWindow = new NewDoctorWindow(docName,docWorkingDays,docWorkingHours);

            //NewDoctorWindow newDocWindow = new NewDoctorWindow();
            newDocWindow.Show();
        }
    }
}
