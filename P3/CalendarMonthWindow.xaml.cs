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
    public partial class CalendarMonthWindow : Window
    {
        private string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        private int currentMonth = DateTime.Now.Month;
        private int currentYear = DateTime.Now.Year;

        public CalendarMonthWindow()
        {
            InitializeComponent();

            loadMonthCal(currentMonth, currentYear);
        }

        //clicking on a day in the calendar
        private void DayBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MonthDayBoxControl dayClicked = (MonthDayBoxControl)sender;
            CalendarDayWindow dayWindow = new CalendarDayWindow(dayClicked.getDay(), this.currentMonth, this.currentYear);
            dayWindow.Owner = this;
            dayWindow.Show();
            this.Hide();
        }

        //loading the month to the calendar
        private void loadMonthCal(int currentMonth, int currentYear)
        {
            monthText.Text = months[currentMonth - 1];
            yearText.Text = currentYear.ToString();
            this.uniformMonthGrid.Children.Clear();

            Random rnd = new Random();

            //offset for day of the week
            for (int i = 0; i < getDayOfWeekOffset(new DateTime(currentYear,currentMonth,1)); i++)
            {
                MonthDayBoxControl hiddenBox = new MonthDayBoxControl();
                this.uniformMonthGrid.Children.Add(hiddenBox);
            }

            //load days
            for (int i = 0; i < DateTime.DaysInMonth(currentYear, currentMonth); i++) //currently using 2018 as placeholder
            {
                MonthDayBoxControl dayBox = new MonthDayBoxControl(i + 1, getNumApptsForAllDoctorsByDay(currentYear, currentMonth, i+1), "Appointment");
                dayBox.MouseLeftButtonDown += DayBox_MouseLeftButtonDown;
                this.uniformMonthGrid.Children.Add(dayBox);
            }
        }


        //decrement month button
        private void leftMonthButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentMonth--;
            if (currentMonth <= 0)
            {
                currentMonth = 12;
                currentYear--;
            }

            loadMonthCal(currentMonth, currentYear);
        }


        //increment month button
        private void rightMonthButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentMonth++;
            if (currentMonth >= 12)
            {
                currentMonth = 1;
                currentYear++;
            }

            loadMonthCal(currentMonth, currentYear);
        }

        //get the offset for the day of week for the calendar
        private int getDayOfWeekOffset(DateTime day)
        {
            DayOfWeek dayOfWeek = day.DayOfWeek;

            return (int)dayOfWeek;
        }

        //gets the number of open appointments for all doctors
        private int getNumApptsForAllDoctorsByDay(int year, int month, int day)
        {
            int numAppts = 0;
            List<Doctor> allDoctors = MediSchedData.getDocList();

            foreach( Doctor doc in allDoctors)
            {
                if (doc.worksOn((int)new DateTime(year, month, day).DayOfWeek))
                {
                    numAppts += MediSchedData.getDaySchedule(doc, year, month, day).getNumAppointments();
                }
            }

            return numAppts;
        }
    }
}
