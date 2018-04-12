using System;
using System.Collections.Generic;
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
            startTBlock1.Text = "";
            startTBlock2.Text = "";
            endTBlock1.Text = "";
            endTBlock2.Text = "";
            this.isEdit = editOrAdd;
        }


        public NewDoctorWindow(string name, string days, string hours, bool editOrAdd)
        {
            InitializeComponent();
            docNameBlock.Text = name;
            this.workingDays = days;
            this.isEdit = editOrAdd;
            string[] amPmSplitter = new string[] { "AM", "PM" };
            
            if (hours.Length != 0)
            {
                startTBlock1.Text = hours.Split('-')[0].Split(':')[0];
                startTBlock2.Text = hours.Split('-')[0].Split(':')[1].Split(amPmSplitter, StringSplitOptions.RemoveEmptyEntries)[0];
                if(hours.Split('-')[0].Contains("AM"))
                {
                    this.amPmComboBox1.SelectedIndex = 0;
                }
                else
                {
                    this.amPmComboBox1.SelectedIndex = 1;
                }

                endTBlock1.Text = hours.Split('-')[1].Split(':')[0];
                endTBlock2.Text = hours.Split('-')[1].Split(':')[1].Split(amPmSplitter, StringSplitOptions.RemoveEmptyEntries)[0];
                if (hours.Split('-')[1].Contains("AM"))
                {
                    this.amPmComboBox2.SelectedIndex = 0;
                }
                else
                {
                    this.amPmComboBox2.SelectedIndex = 1;
                }

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
            DoctorsWindow parentDoc = (DoctorsWindow)this.Owner;
            string cbox1Val = "";
            string cbox2Val = "";

            canAdd = true;

            if (parentDoc != null)
            {
                Doctor rowToBeUpdated = (Doctor)parentDoc.docListGrid.SelectedItem;

                string dash = "-";
                if (startTBlock1.Text.Length == 0 && startTBlock2.Text.Length == 0 && endTBlock1.Text.Length == 0 && endTBlock2.Text.Length == 0)
                {
                    dash = "";
                }

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

                //check if name or time is empty
                /*
                 * if (string.IsNullOrEmpty(startTBlock1.Text.Trim()) || string.IsNullOrEmpty(startTBlock2.Text.Trim()) ||
                    !Regex.IsMatch(startTBlock1.Text, @"^[0-9]*$") || !Regex.IsMatch(startTBlock2.Text, @"^[0-9]*$"))
                    */
                if (string.IsNullOrEmpty(startTBlock1.Text.Trim()) || string.IsNullOrEmpty(startTBlock2.Text.Trim()) ||
                !Regex.IsMatch(startTBlock1.Text, @"^[0-9]*$") || !Regex.IsMatch(startTBlock2.Text, @"^\d{2}$"))
                {
                    canAdd = false;
                    startTBlock1.BorderBrush = new SolidColorBrush(Colors.Red);
                    startTBlock2.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    startTBlock1.BorderBrush = new SolidColorBrush(Colors.Gray);
                    startTBlock2.BorderBrush = new SolidColorBrush(Colors.Gray);
                }

                if (string.IsNullOrEmpty(endTBlock1.Text.Trim()) || string.IsNullOrEmpty(endTBlock2.Text.Trim()) ||
                    !Regex.IsMatch(endTBlock1.Text, @"^[0-9]*$") || !Regex.IsMatch(endTBlock2.Text, @"^\d{2}$"))
                {
                    canAdd = false;
                    endTBlock1.BorderBrush = new SolidColorBrush(Colors.Red);
                    endTBlock2.BorderBrush = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    endTBlock1.BorderBrush = new SolidColorBrush(Colors.Gray);
                    endTBlock2.BorderBrush = new SolidColorBrush(Colors.Gray);
                }
                
                //check for valid time
                if(canAdd)
                {
                    if ((this.amPmComboBox1.SelectedIndex == 1 && this.amPmComboBox2.SelectedIndex == 0) || (this.amPmComboBox1.SelectedIndex == this.amPmComboBox2.SelectedIndex)  && 
                        (Int32.Parse(startTBlock1.Text) > Int32.Parse(endTBlock1.Text) ||(Int32.Parse(startTBlock2.Text) > Int32.Parse(endTBlock2.Text)) && 
                        Int32.Parse(startTBlock1.Text) > 12 || Int32.Parse(endTBlock1.Text) > 12 || Int32.Parse(startTBlock2.Text) > 59 || Int32.Parse(endTBlock2.Text) > 59))
                    {
                        canAdd = false;

                        startTBlock1.BorderBrush = new SolidColorBrush(Colors.Red);
                        startTBlock2.BorderBrush = new SolidColorBrush(Colors.Red);
                        endTBlock1.BorderBrush = new SolidColorBrush(Colors.Red);
                        endTBlock2.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    else
                    {
                        startTBlock1.BorderBrush = new SolidColorBrush(Colors.Gray);
                        startTBlock2.BorderBrush = new SolidColorBrush(Colors.Gray);
                        endTBlock1.BorderBrush = new SolidColorBrush(Colors.Gray);
                        endTBlock2.BorderBrush = new SolidColorBrush(Colors.Gray);
                    }
                }
                

                if (canAdd)
                {

                    //canAdd = true;
                    
                    //if row is selected and edit button is clicked
                    if (rowToBeUpdated != null && isEdit == true)
                    {
                        cbox1Val = amPmComboBox1.Text;
                        cbox2Val = amPmComboBox2.Text;

                        rowToBeUpdated.Name = docNameBlock.Text;
                        rowToBeUpdated.Hours = startTBlock1.Text + ':' + startTBlock2.Text + cbox1Val + dash + endTBlock1.Text + ':' + endTBlock2.Text + cbox2Val;
                        rowToBeUpdated.Days = this.workingDays;

                        //MediSchedData.updateDocInfo(rowToBeUpdated.ID, rowToBeUpdated.Name, rowToBeUpdated.Hours, rowToBeUpdated.Days);
                        MediSchedData.updateDoc(rowToBeUpdated);
                        parentDoc.docListGrid.Items.Refresh();
                    }
                    else if (isEdit == false)   //otherwise they clicked the add new doctor button
                    {
                        cbox1Val = amPmComboBox1.Text;
                        cbox2Val = amPmComboBox2.Text;

                        List<Doctor> docLs = MediSchedData.getDocList();
                        int lastID = 0;

                        if (docLs.Count != 0)
                        {
                            lastID = docLs[docLs.Count - 1].ID;
                        }

                        Doctor newDoc = new Doctor(docNameBlock.Text, this.workingDays, (startTBlock1.Text + ':' + startTBlock2.Text + cbox1Val + dash + endTBlock1.Text + ':' + endTBlock2.Text + cbox2Val));
                        parentDoc.docListGrid.Items.Add(newDoc);
                        MediSchedData.addDocToList(newDoc);
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
