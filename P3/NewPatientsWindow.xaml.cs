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
        public NewPatientsWindow()
        {
            InitializeComponent();
        }
        private void OkButtonStyle(object sender, RoutedEventArgs e)
        {
            this.Close();
            NewApptMonth apptmonthWindow = new NewApptMonth();
            apptmonthWindow.Show();
        }
    }
}
