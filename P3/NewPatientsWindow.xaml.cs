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
            InitializeComponent();
            this.fromAppointment = fromAppointment;
        }

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

            
            /*if (string.IsNullOrEmpty(ageBlock.Text.Trim()))
            {
                canClose = false;
                ageBlock.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            else
            {
                ageBlock.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            */

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
