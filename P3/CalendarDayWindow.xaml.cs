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
    public partial class CalendarDayWindow : Window
    {
        private bool backButtoned = false;
        private DateTime time;

        public CalendarDayWindow(int day, int month, int year)
        {
            InitializeComponent();

            this.time = new DateTime(year, month, day);
            this.dateText.Text = time.ToString("d MMM yyyy");

            for (int i = 0; i < 3; i++)
            {
                //SchedDayControl schedDay = new SchedDayControl("Doctor A");
                SchedDayControl schedDay = new SchedDayControl(new Doctor() { Name = "Arshe D", Days = "MTWR", Hours = "8:00 20:30" }, new DaySchedule());
                this.scheduleGrid.Children.Add(schedDay);
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            //do my stuff before closing
            if (!this.backButtoned)
                this.Owner.Close();
            else
                this.Owner.Show();

            base.OnClosing(e);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            this.backButtoned = true;

            this.Close();
        }
    }
}
