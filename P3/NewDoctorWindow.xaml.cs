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
    /// Interaction logic for NewDoctorWindow.xaml
    /// </summary>
    public partial class NewDoctorWindow : Window
    {
        private string docName;
        private string docWorkingDays;
        private string docWorkingHours;
        private enum Day {M, T, W, TH, F};

        public NewDoctorWindow()
        {
            InitializeComponent();

           
           /* if (!(docName == null & docWorkingDays == null & docStartT == null))
            {
            
            }
            */
            
        }


        public NewDoctorWindow(string name, string days, string hours)
        {
              InitializeComponent();
            this.docName = name;
            this.docWorkingDays = days;
            this.docWorkingHours = hours;
            setupDocInfo();
        }


        private void setupDocInfo()
        {
            docNameToDisplay.Text = this.docName;
            startT.Text = this.docWorkingHours;
            string[] ssize = this.docWorkingHours.Split(null);
            //MessageBox.Show("INFO GOT:" + "docName = " + this.docName + ", docWorkingDays = " + this.docWorkingDays);

            if (mondayBox.IsChecked == false & docWorkingDays.Contains("M"))
            {
                mondayBox.IsChecked = true;
            }
            if (tuesdayBox.IsChecked == false & docWorkingDays.Contains("T"))
            {
                tuesdayBox.IsChecked = true;
            }
            if (wednesdayBox.IsChecked == false & docWorkingDays.Contains("W"))
            {
                wednesdayBox.IsChecked = true;
            }
            if (thursdayBox.IsChecked == false & docWorkingDays.Contains("R"))
            {
                thursdayBox.IsChecked = true;
            }
            if (fridayBox.IsChecked == false & docWorkingDays.Contains("F"))
            {
                fridayBox.IsChecked = true;
            }

            

        }

    }
}
