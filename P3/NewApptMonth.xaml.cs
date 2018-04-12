using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    public partial class NewApptMonth : Window
    {
        private string[] months = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
        private int currentMonth = DateTime.Now.Month;
        private int currentYear = DateTime.Now.Year;
        private string apptType = "Appointment Type 1";
        private int potentialLength = 1;

        private Patient targetPatient = null;

        //create the new month
        public NewApptMonth(Patient selectedPatient)
        {
            NewApptMonth.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            NewApptMonth.newWindowOpened(this, null);

            InitializeComponent();

            this.targetPatient = selectedPatient;

            loadMonthCal(potentialLength, currentMonth, currentYear);

            this.typeComboBox.SelectedIndex = 0; //sets default selection
            this.apptType = this.typeComboBox.SelectedValue.ToString();
            this.durationComboBox.SelectedIndex = 0; //sets default selection
        }

        //handles when the main window closes, closes this window
        private void handleMainClose(object sender, EventArgs e)
        {
            this.Close();
        }

        //handles a new appt window being opened
        //if a new window of this type opens, closes the others
        private void handleNewWindow(object sender, EventArgs e)
        {
            if ((sender as NewApptMonth) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            NewApptMonth.newWindowOpened -= handleNewWindow;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };

        //clicking on a day
        private void DayBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MonthDayBoxControl dayClicked = (MonthDayBoxControl)sender;
            NewApptDay dayWindow = new NewApptDay(dayClicked.getDay(), this.currentMonth, this.currentYear, potentialLength, apptType, targetPatient);
            dayWindow.Owner = this;
            dayWindow.Show();
            this.Hide();
        }

        //select appointment - currently these are stubs
        private void cmbType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.typeComboBox.SelectedValue != null)
                this.apptType = this.typeComboBox.SelectedValue.ToString();
        }

        //select meeting block
        private void cmbDuration_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.durationComboBox.SelectedValue != null)
            {
                string duration = this.durationComboBox.SelectedValue.ToString();
                switch (duration)
                {
                    case "0:30":
                        this.potentialLength = 1;
                        break;
                    case "1:00":
                        this.potentialLength = 2;
                        break;
                    case "1:30":
                        this.potentialLength = 3;
                        break;
                    case "2:00":
                        this.potentialLength = 4;
                        break;
                    case "2:30":
                        this.potentialLength = 5;
                        break;
                    case "3:00":
                        this.potentialLength = 6;
                        break;
                    case "3:30":
                        this.potentialLength = 7;
                        break;
                    case "4:00":
                        this.potentialLength = 8;
                        break;
                    case "4:30":
                        this.potentialLength = 9;
                        break;
                    case "5:00":
                        this.potentialLength = 10;
                        break;
                }

                loadMonthCal(potentialLength, currentMonth, currentYear);
            }
        }

        //takes the potential length for future calculations
        private void loadMonthCal(int potentialLength, int currentMonth, int currentYear)
        {
            monthText.Text = months[currentMonth - 1];
            yearText.Text = currentYear.ToString();
            this.uniformMonthGrid.Children.Clear();

            Random rnd = new Random();

            //offset for day of the week
            for (int i = 0; i < getDayOfWeekOffset(new DateTime(currentYear, currentMonth, 1)); i++)
            {
                MonthDayBoxControl hiddenBox = new MonthDayBoxControl();
                this.uniformMonthGrid.Children.Add(hiddenBox);
            }

            //load days
            for (int i = 0; i < DateTime.DaysInMonth(currentYear, currentMonth); i++) //currently using 2018 as placeholder
            {
                MonthDayBoxControl dayBox = new MonthDayBoxControl(i + 1, getNumSlotsForAllDoctorsByDay(currentYear, currentMonth, i+1), "Slot");
                dayBox.MouseLeftButtonDown += DayBox_MouseLeftButtonDown;
                this.uniformMonthGrid.Children.Add(dayBox);
            }
        }

        //decrement month
        private void leftMonthButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentMonth--;
            if(currentMonth <= 0)
            {
                currentMonth = 12;
                currentYear--;
            }

            loadMonthCal(potentialLength, currentMonth, currentYear);
        }

        //increment month
        private void rightMonthButton_Click(object sender, RoutedEventArgs e)
        {
            this.currentMonth++;
            if (currentMonth >= 12)
            {
                currentMonth = 1;
                currentYear++;
            }

            loadMonthCal(potentialLength, currentMonth, currentYear);
        }

        //gets the offset fromt he start for a day of the week
        private int getDayOfWeekOffset(DateTime day)
        {
            DayOfWeek dayOfWeek = day.DayOfWeek;

            return (int)dayOfWeek;
        }

        //gets the number of open appointments for all doctors
        private int getNumSlotsForAllDoctorsByDay(int year, int month, int day)
        {
            int numAppts = 0;
            List<Doctor> allDoctors = MediSchedData.getDocList();

            foreach (Doctor doc in allDoctors)
            {
                if (doc.worksOn((int)new DateTime(year, month, day).DayOfWeek))
                {
                    numAppts += MediSchedData.getDaySchedule(doc, year, month, day).getNumSlots(potentialLength,doc.getStartBlock(), doc.getEndBlock());
                }
            }

            return numAppts;
        }
    }
}
