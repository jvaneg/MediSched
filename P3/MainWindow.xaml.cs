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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime time;

        public MainWindow()
        {
            MediSchedData.setUpFakeDb(); //setting up the fake database
            
            InitializeComponent();

            MediSchedData.dbChanged += handleDbChange;

            loadDaySchedules();
        }

        //reloads the page when the db changes
        private void handleDbChange(object sender, EventArgs e)
        {
            loadDaySchedules();
        }

        private void newApptButton_Click(object sender, RoutedEventArgs e)
        {
            NewApptWindow newApptWindow = new NewApptWindow();
            newApptWindow.Owner = this;
            newApptWindow.Show();
        }

        private void patientsButton_Click(object sender, RoutedEventArgs e)
        {
            
                PatientsWindow patientsWindow = new PatientsWindow();
                patientsWindow.Owner = this;
                patientsWindow.Show();
            

           /* 
            * PatientInfo patientinfo = new PatientInfo();
            patientinfo.Show();
            */
        }

        private void sampleApptButton_Click(object sender, RoutedEventArgs e)
        {
            ApptWindow apptWindow = new ApptWindow();
            apptWindow.Owner = this;
            apptWindow.Show();
        }

        private void calendarButton_Click(object sender, RoutedEventArgs e)
        {
            CalendarMonthWindow calMonth = new CalendarMonthWindow();
            calMonth.Owner = this;
            calMonth.Show();
        }

        private void doctorsButton_Click(object sender, RoutedEventArgs e)
        {
            
            DoctorsWindow docWindow =  new DoctorsWindow();
            docWindow.Owner = this;
            docWindow.Show();
        }

        //loads the day schedules and updates the date
        private void loadDaySchedules()
        {
            this.time = DateTime.Now;
            this.dateText.Text = time.ToString("d MMM yyyy");

            SchedDayControl schedDay = null;
            List<Doctor> allDoctors = MediSchedData.getDocList();

            this.scheduleGrid.Children.Clear();

            foreach (Doctor doc in allDoctors)
            {
                if (doc.worksOn((int)time.DayOfWeek))
                {
                    schedDay = new SchedDayControl(doc, MediSchedData.getDaySchedule(doc, time.Year, time.Month, time.Day));
                    this.scheduleGrid.Children.Add(schedDay);
                }
            }
        }

    }
}
