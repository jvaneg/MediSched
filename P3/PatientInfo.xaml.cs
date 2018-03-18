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
        }

        private void BackupButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Information backed up");
        }
        
        private void EditPersonalInfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can edit personal info now");
        }

        private void EditBillingInfoButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You can edit billing info now");
        }
    }
}
