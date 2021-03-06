﻿using System;
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

using System.Data;
using System.Collections.ObjectModel;

namespace P3
{
    /// <summary>
    /// Interaction logic for NewDoctorsWindow.xaml
    /// </summary>
    public partial class DoctorsWindow : Window
    {
        //DataTable dt = new DataTable();

        //initially loading data fromt he big boy fake database
        public DoctorsWindow()
        {
            DoctorsWindow.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            DoctorsWindow.newWindowOpened(this, null);

            InitializeComponent();

            //load data
            List<Doctor> ls = MediSchedData.getDocList();
            if(ls.Count > 0)
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    //docListGrid.Items.Add(new Doctor() {ID = ls[i].ID, Name = ls[i].Name, Days = ls[i].Days, Hours = ls[i].Hours });
                    docListGrid.Items.Add(ls[i]);
                }
            }
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
            if ((sender as DoctorsWindow) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            DoctorsWindow.newWindowOpened -= handleNewWindow;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };


        //when the user clicks the add doctor button +
        private void addDoctorButton_Click(object sender, RoutedEventArgs e)
         {

             NewDoctorWindow newDocWindow = new NewDoctorWindow(false);  //false-> clear edit mode
             newDocWindow.Owner = this;
             newDocWindow.Show();
         }

        //when the user clicks the edit doctor button
        private void editDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (docListGrid.SelectedItem != null)
            {
                Doctor doc = (Doctor)docListGrid.SelectedItem;
                NewDoctorWindow newDocWindow = new NewDoctorWindow(doc.Name, doc.Days, doc.Hours, true); //true -> set edit mode
                newDocWindow.Owner = this;
                newDocWindow.Show();

            }
        }

        //when the user clicks the delete doctor button
        private void deleteDoctorButton_Click(object sender, RoutedEventArgs e)
        {
            if (docListGrid.SelectedItem != null)
            {
                MediSchedData.deleteDoc((docListGrid.SelectedItem as Doctor));
                docListGrid.Items.Remove(docListGrid.SelectedItem);
            }
        }
    }
}
