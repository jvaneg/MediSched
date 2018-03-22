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
        
        private string docWorkingDays;
        bool isEdit;
        public NewDoctorWindow(bool editOrAdd)
        {
            InitializeComponent();
            this.docWorkingDays = "";
            docNameBlock.Text = "";
            startTBlock.Text = "";
            endTBlock.Text = "";
            this.isEdit = editOrAdd;
        }

        public NewDoctorWindow()
        {
            InitializeComponent();
        }

        public NewDoctorWindow(string name, string days, string hours, bool editOrAdd)
        {
            InitializeComponent();
            docNameBlock.Text = name;
            this.docWorkingDays = days;
            this.isEdit = editOrAdd;

            startTBlock.Text = hours.Split('-')[0];
            endTBlock.Text = hours.Split('-')[1];

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


        

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //DoctorsWindow parentDoc = (DoctorsWindow)Window.GetWindow(this);

            DoctorsWindow parentDoc = (DoctorsWindow)this.Owner;
            if (parentDoc != null )
            {
                Doctor rowToBeUpdated = (Doctor)parentDoc.docListGrid.SelectedItem;


                if (mondayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("M"))
                {
                    this.docWorkingDays = "M";
                }
                if (tuesdayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("T"))
                {
                    this.docWorkingDays += "T";
                }
                if (wednesdayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("W"))
                {
                    this.docWorkingDays += "W";
                }
                if (thursdayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("R"))
                {
                    this.docWorkingDays += "R";
                }
                if (fridayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("F"))
                {
                    this.docWorkingDays += "F";
                }

                if (rowToBeUpdated != null && isEdit == true)
                {
                    rowToBeUpdated.Name = docNameBlock.Text;
                    rowToBeUpdated.Hours = startTBlock.Text + "-" + endTBlock.Text;

                    rowToBeUpdated.Days = this.docWorkingDays;
                  
                    parentDoc.docListGrid.Items.Refresh();
                }
                else if (isEdit == false)
                {
                    //MessageBox.Show("SETTING INFO:" + "docName = " + docNameBlock.Text +"\nDays = " + this.docWorkingDays +  "\nhours = " + startTBlock.Text + ", " + endTBlock.Text);
                    parentDoc.docListGrid.Items.Add(new Doctor() { Name = docNameBlock.Text, Days = this.docWorkingDays, Hours = (startTBlock.Text + "-" + endTBlock.Text) });
                }
            }
            this.Close();
        }
    }
}
