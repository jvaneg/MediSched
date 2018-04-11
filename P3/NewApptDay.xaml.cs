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
    /// Interaction logic for NewApptMonth.xaml
    /// </summary>
    public partial class NewApptDay : Window
    {
        private bool backButtoned = false;
        private DateTime time;
        private Patient patient = null;
        private int potentialLength = 0;
        private string apptType = "";


        //creates a new day
        public NewApptDay(int day, int month, int year, int potentialLength, string apptType, Patient targetPatient)
        {
            InitializeComponent();

            this.potentialLength = potentialLength;
            this.apptType = apptType;
            this.patient = targetPatient;

            this.time = new DateTime(year, month, day);
            this.dateText.Text = time.ToString("d MMM yyyy");

            MediSchedData.dbChanged += handleDbChange;

            loadDaySchedules();
        }

        //reloads the page when the db changes
        private void handleDbChange(object sender, EventArgs e)
        {
            loadDaySchedules();
        }

        //loads the day schedules
        private void loadDaySchedules()
        {
            SchedDayControl schedDay = null;
            List<Doctor> allDoctors = MediSchedData.getDocList();

            this.scheduleGrid.Children.Clear();

            foreach (Doctor doc in allDoctors)
            {
                if (doc.worksOn((int)time.DayOfWeek))
                {
                    schedDay = new SchedDayControl(doc, MediSchedData.getDaySchedule(doc, time.Year, time.Month, time.Day), this.potentialLength, this.apptType, this.patient, this.time);
                    this.scheduleGrid.Children.Add(schedDay);
                }
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //do my stuff before closing
            if (!this.backButtoned)
                this.Owner.Close();
            else
                this.Owner.Show();

            base.OnClosing(e);
        }

        //press the back button
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.backButtoned = true;

            this.Close();
        }
    }
}
