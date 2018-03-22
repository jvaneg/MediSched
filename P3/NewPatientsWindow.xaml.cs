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
        public NewPatientsWindow(bool fromAppointment)
        {
            InitializeComponent();
            this.fromAppointment = fromAppointment;
        }

        private void OkButtonStyle(object sender, RoutedEventArgs e)
        {
            if (fromAppointment)
            {
                NewApptMonth apptmonthWindow = new NewApptMonth();
                apptmonthWindow.Owner = this.Owner;
                apptmonthWindow.Show();
            }
            else
            {
                //something in the implementation phase
            }
            this.Close();
        }
    }
}
