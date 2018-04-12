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

        //click new appointment button
        private void newApptButton_Click(object sender, RoutedEventArgs e)
        {
            NewApptWindow newApptWindow = new NewApptWindow();
            //newApptWindow.Owner = this; //TODO idk if i should remove this
            newApptWindow.Show();
        }

        //click the patients button
        private void patientsButton_Click(object sender, RoutedEventArgs e)
        {  
            PatientsWindow patientsWindow = new PatientsWindow();
            //patientsWindow.Owner = this; //TODO idk if i should remove this
            patientsWindow.Show();
        }

        //click on the view calendar button
        private void calendarButton_Click(object sender, RoutedEventArgs e)
        {
            CalendarMonthWindow calMonth = new CalendarMonthWindow();
            //calMonth.Owner = this; //TODO idk if i should remove this
            calMonth.Show();
        }

        //click on the doctors button
        private void doctorsButton_Click(object sender, RoutedEventArgs e)
        {
            DoctorsWindow docWindow =  new DoctorsWindow();
            //docWindow.Owner = this; //TODO idk if i should remove this
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


        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            mainClosed(null, null);

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        public static EventHandler mainClosed = delegate { };

    }
}
