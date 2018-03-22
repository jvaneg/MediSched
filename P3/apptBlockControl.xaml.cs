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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P3
{
    /// <summary>
    /// Interaction logic for MonthDayBoxControl.xaml
    /// </summary>
    public partial class ApptBlockControl : UserControl
    {
        private int potentialLength = 1;
        private bool addMode = false;
        private string patientName = "";
        private string apptType = "";
        private bool enabled = false;
        private Color baseColor = (Color)ColorConverter.ConvertFromString("#FFE55039");
        private Color highlightColor = (Color)ColorConverter.ConvertFromString("#FFB71540");

        private int initialHeight = 50;

        public ApptBlockControl()
        {
            InitializeComponent();
            this.apptBlockBack.Fill = new SolidColorBrush(baseColor);
            this.apptBlockBack.Stroke = new SolidColorBrush(highlightColor);
        }

        public void setupAddMode(int potentialLength, string patientName, string apptType)
        {
            this.potentialLength = potentialLength;
            this.addMode = true;
            this.patientName = patientName;
            this.apptType = apptType;
            this.apptBlockText.Text = patientName + "\n" + apptType;
            this.Cursor = Cursors.Hand;
            this.Visibility = Visibility.Visible;
        }

        public void setEnabled(int length, string patientName, string apptType)
        {
            this.enabled = true;
            this.potentialLength = length;
            this.patientName = patientName;
            this.apptType = apptType;
            this.apptBlockText.Text = patientName + "\n" + apptType;
            this.Cursor = Cursors.Hand;
            this.Visibility = Visibility.Visible;
            this.Height = initialHeight * potentialLength;
            this.apptBlockGrid.Height = initialHeight * potentialLength;
            this.Opacity = 100;
            this.addMode = false;
        }

        public bool isEnabled()
        {
            return this.enabled;
        }

        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (addMode)
            {
                this.Height = initialHeight * potentialLength;
                this.apptBlockGrid.Height = initialHeight * potentialLength;
                this.Opacity = 100;
            }
            else if(enabled)
            {
                //transition thing or colour change
                this.apptBlockBack.Fill = new SolidColorBrush(highlightColor);
            }
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (addMode)
            { 
                this.Height = initialHeight;
                this.apptBlockGrid.Height = initialHeight;
                this.Opacity = 0;
            }
            else if (enabled)
            {
                //transition thing or colour change
                this.apptBlockBack.Fill = new SolidColorBrush(baseColor);
            }
        }
    }
}
