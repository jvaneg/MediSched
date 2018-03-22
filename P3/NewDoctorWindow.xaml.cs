using System.Windows;

namespace P3
{
    /// <summary>
    /// Interaction logic for NewDoctorWindow.xaml
    /// </summary>
    public partial class NewDoctorWindow : Window
    {
        private string workingDays;
        bool isEdit;

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

            startTBlock.Text = hours.Split('-')[0];
            endTBlock.Text = hours.Split('-')[1];

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

                if (mondayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("M"))
                    this.workingDays = "M";
                else if (mondayBox.IsChecked == false)
                    this.workingDays = this.workingDays.Replace("M", "");

                if (tuesdayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("T"))
                    this.workingDays += "T";
                else if (tuesdayBox.IsChecked == false)
                    this.workingDays = this.workingDays.Replace("T", "");

                if (wednesdayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("W"))
                    this.workingDays += "W";
                else if (wednesdayBox.IsChecked == false)
                    this.workingDays = this.workingDays.Replace("W", "");

                if (thursdayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("R"))
                    this.workingDays += "R";
                else if (thursdayBox.IsChecked == false)
                    this.workingDays = this.workingDays.Replace("R", "");

                if (fridayBox.IsChecked == true && !rowToBeUpdated.Days.Contains("F"))
                    this.workingDays += "F";
                else if (fridayBox.IsChecked == false)
                    this.workingDays = this.workingDays.Replace("F", "");

                //if row is selected and edit button is clicked
                if (rowToBeUpdated != null && isEdit == true)
                {
                    rowToBeUpdated.Name = docNameBlock.Text;
                    rowToBeUpdated.Hours = startTBlock.Text + "-" + endTBlock.Text;
                    rowToBeUpdated.Days = this.workingDays;
                  
                    parentDoc.docListGrid.Items.Refresh();
                }
                else if (isEdit == false)   //otherwise they clicked the add new doctor button
                {
                    //MessageBox.Show("SETTING INFO:" + "docName = " + docNameBlock.Text +"\nDays = " + this.docWorkingDays +  "\nhours = " + startTBlock.Text + ", " + endTBlock.Text);
                    parentDoc.docListGrid.Items.Add(new Doctor() { Name = docNameBlock.Text, Days = this.workingDays, Hours = (startTBlock.Text + "-" + endTBlock.Text) });
                }
            }
            this.Close();
        }
    }
}
