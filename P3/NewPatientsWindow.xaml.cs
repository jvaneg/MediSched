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
    /// Interaction logic for NewPatientsWindow.xaml
    /// </summary>
    public partial class NewPatientsWindow : Window
    {
        bool fromAppointment = false;

        //initialize new patient window depending on if its from a new appointment window
        public NewPatientsWindow(bool fromAppointment)
        {
            NewPatientsWindow.newWindowOpened += handleNewWindow;
            MainWindow.mainClosed += handleMainClose;
            NewPatientsWindow.newWindowOpened(this, null);

            InitializeComponent();
            this.fromAppointment = fromAppointment;
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
            if ((sender as NewPatientsWindow) != this)
            {
                //save maybe
                this.Close();
            }
        }

        //special close logic
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            NewPatientsWindow.newWindowOpened -= handleNewWindow;
            MainWindow.mainClosed -= handleMainClose;

            base.OnClosing(e);
        }

        //event for when new window of this type is opened
        private static EventHandler newWindowOpened = delegate { };

        //press ok on new patient window
        private void OkButtonStyle(object sender, RoutedEventArgs e)
        {
            bool canClose = true;
            //maybe prevent from adding patient with no name

            if (string.IsNullOrEmpty(nameBlock.Text.Trim()))
            {
                canClose = false;
                nameBlock.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                nameBlock.BorderBrush = new SolidColorBrush(Colors.Gray);
            }

            if (canClose)
            {
                //create patient from form data
                Patient newPatient = new Patient(this.nameBlock.Text, this.emailBlock.Text, this.streetBlock.Text, this.cityBlock.Text, this.provBlock.Text, this.countryBlock.Text, this.phoneBlock.Text,
                                                 this.ageBlock.Text, this.bloodBlock.Text, this.billStreetBox.Text, this.billCityBox.Text, this.billProvBox.Text, this.billCountryBox.Text, this.billPhoneBox.Text,
                                                 this.billPostalBox.Text);

                MediSchedData.addPatientToList(newPatient);


                if (fromAppointment)
                {
                    NewApptMonth apptmonthWindow = new NewApptMonth(newPatient);
                    apptmonthWindow.Owner = this.Owner;
                    apptmonthWindow.Show();
                }
                else
                {
                    //maybe open the thing for that patient but probably not
                }

                this.Close();
            }
        }
    }
}
