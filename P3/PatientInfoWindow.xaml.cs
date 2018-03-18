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
    /// Interaction logic for PatientInfo.xaml
    /// </summary>
    public partial class PatientInfo : Window
    {
        public PatientInfo()
        {
            InitializeComponent();

            this.nameBox.Visibility = Visibility.Hidden;
            this.emailBox.Visibility = Visibility.Hidden;
            this.streetBox.Visibility = Visibility.Hidden;
            this.cityBox.Visibility = Visibility.Hidden;
            this.provBox.Visibility = Visibility.Hidden;
            this.countryBox.Visibility = Visibility.Hidden;
            this.phoneBox.Visibility = Visibility.Hidden;
            this.ageBox.Visibility = Visibility.Hidden;
            this.bloodBox.Visibility = Visibility.Hidden;

            this.nameBlock.Visibility = Visibility.Visible;
            this.emailBlock.Visibility = Visibility.Visible;
            this.streetBlock.Visibility = Visibility.Visible;
            this.cityBlock.Visibility = Visibility.Visible;
            this.provBlock.Visibility = Visibility.Visible;
            this.countryBlock.Visibility = Visibility.Visible;
            this.phoneBlock.Visibility = Visibility.Visible;
            this.ageBlock.Visibility = Visibility.Visible;
            this.bloodBlock.Visibility = Visibility.Visible;

            this.editPersButton.Visibility = Visibility.Visible;
            this.savePersButton.Visibility = Visibility.Hidden;

            this.billStreetBox.Visibility = Visibility.Hidden;
            this.billCityBox.Visibility = Visibility.Hidden;
            this.billProvBox.Visibility = Visibility.Hidden;
            this.billCountryBox.Visibility = Visibility.Hidden;
            this.billPhoneBox.Visibility = Visibility.Hidden;
            this.billPostalBox.Visibility = Visibility.Hidden;

            this.billStreetBlock.Visibility = Visibility.Visible;
            this.billCityBlock.Visibility = Visibility.Visible;
            this.billProvBlock.Visibility = Visibility.Visible;
            this.billCountryBlock.Visibility = Visibility.Visible;
            this.billPhoneBlock.Visibility = Visibility.Visible;
            this.billPostalBlock.Visibility = Visibility.Visible;

            this.editBillButton.Visibility = Visibility.Visible;
            this.saveBillButton.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void savePersonal()
        {
            this.nameBox.Visibility = Visibility.Hidden;
            this.emailBox.Visibility = Visibility.Hidden;
            this.streetBox.Visibility = Visibility.Hidden;
            this.cityBox.Visibility = Visibility.Hidden;
            this.provBox.Visibility = Visibility.Hidden;
            this.countryBox.Visibility = Visibility.Hidden;
            this.phoneBox.Visibility = Visibility.Hidden;
            this.ageBox.Visibility = Visibility.Hidden;
            this.bloodBox.Visibility = Visibility.Hidden;

            this.nameBlock.Text = this.nameBox.Text;
            this.emailBlock.Text = this.emailBox.Text;
            this.streetBlock.Text = this.streetBox.Text;
            this.cityBlock.Text = this.cityBox.Text;
            this.provBlock.Text = this.provBox.Text;
            this.countryBlock.Text = this.countryBox.Text;
            this.phoneBlock.Text = this.phoneBox.Text;
            this.ageBlock.Text = this.ageBox.Text;
            this.bloodBlock.Text = this.bloodBox.Text;

            this.displayPatientname.Text = this.nameBox.Text;

            this.nameBlock.Visibility = Visibility.Visible;
            this.emailBlock.Visibility = Visibility.Visible;
            this.streetBlock.Visibility = Visibility.Visible;
            this.cityBlock.Visibility = Visibility.Visible;
            this.provBlock.Visibility = Visibility.Visible;
            this.countryBlock.Visibility = Visibility.Visible;
            this.phoneBlock.Visibility = Visibility.Visible;
            this.ageBlock.Visibility = Visibility.Visible;
            this.bloodBlock.Visibility = Visibility.Visible;

            
        }

        private void editPersonal()
        {
            this.nameBlock.Visibility = Visibility.Hidden;
            this.emailBlock.Visibility = Visibility.Hidden;
            this.streetBlock.Visibility = Visibility.Hidden;
            this.cityBlock.Visibility = Visibility.Hidden;
            this.provBlock.Visibility = Visibility.Hidden;
            this.countryBlock.Visibility = Visibility.Hidden;
            this.phoneBlock.Visibility = Visibility.Hidden;
            this.ageBlock.Visibility = Visibility.Hidden;
            this.bloodBlock.Visibility = Visibility.Hidden;

            this.nameBox.Text = this.nameBlock.Text;
            this.emailBox.Text = this.emailBlock.Text;
            this.streetBox.Text = this.streetBlock.Text;
            this.cityBox.Text = this.cityBlock.Text;
            this.provBox.Text = this.provBlock.Text;
            this.countryBox.Text = this.countryBlock.Text;
            this.phoneBox.Text = this.phoneBlock.Text;
            this.ageBox.Text = this.ageBlock.Text;
            this.bloodBox.Text = this.bloodBlock.Text;

            this.nameBox.Visibility = Visibility.Visible;
            this.emailBox.Visibility = Visibility.Visible;
            this.streetBox.Visibility = Visibility.Visible;
            this.cityBox.Visibility = Visibility.Visible;
            this.provBox.Visibility = Visibility.Visible;
            this.countryBox.Visibility = Visibility.Visible;
            this.phoneBox.Visibility = Visibility.Visible;
            this.ageBox.Visibility = Visibility.Visible;
            this.bloodBox.Visibility = Visibility.Visible;
        }

        private void saveBilling()
        {
            this.billStreetBox.Visibility = Visibility.Hidden;
            this.billCityBox.Visibility = Visibility.Hidden;
            this.billProvBox.Visibility = Visibility.Hidden;
            this.billCountryBox.Visibility = Visibility.Hidden;
            this.billPhoneBox.Visibility = Visibility.Hidden;
            this.billPostalBox.Visibility = Visibility.Hidden;

            this.billStreetBlock.Text = this.billStreetBox.Text;
            this.billCityBlock.Text = this.billCityBox.Text;
            this.billProvBlock.Text = this.billProvBox.Text;
            this.billCountryBlock.Text = this.billCountryBox.Text;
            this.billPhoneBlock.Text = this.billPhoneBox.Text;
            this.billPostalBlock.Text = this.billPostalBox.Text;

            this.billStreetBlock.Visibility = Visibility.Visible;
            this.billCityBlock.Visibility = Visibility.Visible;
            this.billProvBlock.Visibility = Visibility.Visible;
            this.billCountryBlock.Visibility = Visibility.Visible;
            this.billPhoneBlock.Visibility = Visibility.Visible;
            this.billPostalBlock.Visibility = Visibility.Visible;
        }

        private void editBilling()
        {
            this.billStreetBlock.Visibility = Visibility.Hidden;
            this.billCityBlock.Visibility = Visibility.Hidden;
            this.billProvBlock.Visibility = Visibility.Hidden;
            this.billCountryBlock.Visibility = Visibility.Hidden;
            this.billPhoneBlock.Visibility = Visibility.Hidden;
            this.billPostalBlock.Visibility = Visibility.Hidden;

            this.billStreetBox.Text = this.billStreetBlock.Text;
            this.billCityBox.Text = this.billCityBlock.Text;
            this.billProvBox.Text = this.billProvBlock.Text;
            this.billCountryBox.Text = this.billCountryBlock.Text;
            this.billPhoneBox.Text = this.billPhoneBlock.Text;
            this.billPostalBox.Text = this.billPostalBlock.Text;

            this.billStreetBox.Visibility = Visibility.Visible;
            this.billCityBox.Visibility = Visibility.Visible;
            this.billProvBox.Visibility = Visibility.Visible;
            this.billCountryBox.Visibility = Visibility.Visible;
            this.billPhoneBox.Visibility = Visibility.Visible;
            this.billPostalBox.Visibility = Visibility.Visible;
        }

        private void BackupButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Information backed up");
        }
        
        private void EditPersonalInfoButton_Click(object sender, RoutedEventArgs e)
        {
            editPersonal();
            this.editPersButton.Visibility = Visibility.Hidden;
            this.savePersButton.Visibility = Visibility.Visible;
        }

        private void EditBillingInfoButton_Click(object sender, RoutedEventArgs e)
        {
            editBilling();
            this.editBillButton.Visibility = Visibility.Hidden;
            this.saveBillButton.Visibility = Visibility.Visible;
        }

        private void savePersButton_Click(object sender, RoutedEventArgs e)
        {
            savePersonal();
            this.editPersButton.Visibility = Visibility.Visible;
            this.savePersButton.Visibility = Visibility.Hidden;
        }

        private void saveBillButton_Click(object sender, RoutedEventArgs e)
        {
            saveBilling();
            this.editBillButton.Visibility = Visibility.Visible;
            this.saveBillButton.Visibility = Visibility.Hidden;
        }

        private void appt_Selected(object sender, RoutedEventArgs e)
        {
            ApptWindow apptWindow = new ApptWindow();
            apptWindow.Show();
        }
    }
}
