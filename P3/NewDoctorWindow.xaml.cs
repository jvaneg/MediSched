using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace P3
{
    /// <summary>
    /// Interaction logic for NewDoctorWindow.xaml
    /// </summary>
    public partial class NewDoctorWindow : Window
    {
        private string workingDays;
        bool isEdit;
        bool canAdd = true;
        bool isM = false;
        bool isT = false;
        bool isW = false;
        bool isR = false;
        bool isF = false;
        

        public NewDoctorWindow(bool editOrAdd)
        {
            InitializeComponent();
            this.workingDays = "";
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
            this.workingDays = days;
            this.isEdit = editOrAdd;

            if (hours.Length != 0)
            {
                startTBlock.Text = hours.Split('-')[0];
                endTBlock.Text = hours.Split('-')[1];
            }

            if (mondayBox.IsChecked == false & workingDays.Contains("M"))
                mondayBox.IsChecked = true;

            if (tuesdayBox.IsChecked == false & workingDays.Contains("T"))
                tuesdayBox.IsChecked = true;

            if (wednesdayBox.IsChecked == false & workingDays.Contains("W"))
                wednesdayBox.IsChecked = true;

            if (thursdayBox.IsChecked == false & workingDays.Contains("R"))
                thursdayBox.IsChecked = true;

            if (fridayBox.IsChecked == false & workingDays.Contains("F"))
                fridayBox.IsChecked = true;

        }


        

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //DoctorsWindow parentDoc = (DoctorsWindow)Window.GetWindow(this);

            DoctorsWindow parentDoc = (DoctorsWindow)this.Owner;
            if (parentDoc != null )
            {

                Doctor rowToBeUpdated = (Doctor)parentDoc.docListGrid.SelectedItem;

                string dash = "-";
                if (startTBlock.Text.Length == 0 && startTBlock.Text.Length == 0)
                    dash = "";


                if (mondayBox.IsChecked == true)
                    isM = true;
                else if (mondayBox.IsChecked == false)
                    isM = false;

                if (tuesdayBox.IsChecked == true)
                    isT = true;
                else if (tuesdayBox.IsChecked == false)
                    isT = false;

                if (wednesdayBox.IsChecked == true)
                    isW = true;
                else if (wednesdayBox.IsChecked == false)
                    isW = false;

                if (thursdayBox.IsChecked == true)
                    isR = true;
                else if (thursdayBox.IsChecked == false)
                    isR = false;

                if (fridayBox.IsChecked == true)
                   isF = true;
                else if (fridayBox.IsChecked == false)
                    isF = false;

                this.workingDays = "";

                if (isM)
                    this.workingDays = "M";

                if (isT)
                    this.workingDays += "T";

                if (isW)
                    this.workingDays += "W";

                if (isR)
                    this.workingDays += "R";

                if (isF)
                {
                    this.workingDays += "F";
                }

                
                if (string.IsNullOrEmpty(docNameBlock.Text.Trim()))
                {
                    canAdd = false;
                    docNameBlock.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    docNameBlock.BorderBrush = new SolidColorBrush(Colors.Gray);
                }

                if (string.IsNullOrEmpty(startTBlock.Text.Trim()) || !Regex.IsMatch(startTBlock.Text, @"^[0-9:]*$"))
                {
                    canAdd = false;
                    startTBlock.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    docNameBlock.BorderBrush = new SolidColorBrush(Colors.Gray);
                }

                if (string.IsNullOrEmpty(endTBlock.Text.Trim()) || !Regex.IsMatch(endTBlock.Text, @"^[0-9:]*$"))
                {
                    canAdd = false;
                    endTBlock.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    endTBlock.BorderBrush = new SolidColorBrush(Colors.Gray);
                }


                if (canAdd)
                {
                    canAdd = true;

                    //if row is selected and edit button is clicked
                    if (rowToBeUpdated != null && isEdit == true)
                    {
                        rowToBeUpdated.Name = docNameBlock.Text;
                        rowToBeUpdated.Hours = startTBlock.Text + dash + endTBlock.Text;
                        rowToBeUpdated.Days = this.workingDays;

                        parentDoc.docListGrid.Items.Refresh();
                    }
                    else if (isEdit == false)   //otherwise they clicked the add new doctor button
                    {
                        parentDoc.docListGrid.Items.Add(new Doctor() { Name = docNameBlock.Text, Days = this.workingDays, Hours = (startTBlock.Text + dash + endTBlock.Text) });
                    }
                }
            }
            if(canAdd)
            {
                this.Close();
            }
        }
    }
}
