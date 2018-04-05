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
        private bool enabled = false; //whether or not it contains an appointment
        private Color baseColor = (Color)ColorConverter.ConvertFromString("#FFE55039");
        private Color highlightColor = (Color)ColorConverter.ConvertFromString("#FFB71540");
        private Color greyedOutColor = (Color)ColorConverter.ConvertFromString("#FFD3D3D3");
        private string apptStatus = "Not Arrived";
        private int initialHeight = 50;
        Appointment apptRepresenting = null;

        public ApptBlockControl()
        {
            InitializeComponent();
            setApptStatus(apptStatus);
        }

        //sets up a block for add mode
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

        //disables add mode on a block
        public void disableAddMode()
        {
            this.addMode = false;
            this.enabled = false;
            this.Cursor = Cursors.Arrow;
            this.Visibility = Visibility.Hidden;
        }

        //enables the box (depricated)
        public void setEnabled(int length, string patientName, string apptType, string apptStatus) //replace apptStatus string with enum probably
        {
            setApptStatus(apptStatus);

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

        //loads an appointment
        public void loadAppointment(Appointment appt)
        {
            this.apptRepresenting = appt;
            this.enabled = true;
            this.potentialLength = appt.getApptBlockLength();
            this.patientName = appt.getPatientName();
            this.apptType = appt.getApptType();
            setApptStatus(appt.getApptStatus());
            this.apptBlockText.Text = patientName + "\n" + apptType;
            this.Cursor = Cursors.Hand;
            this.Visibility = Visibility.Visible;
            this.Height = initialHeight * potentialLength;
            this.apptBlockGrid.Height = initialHeight * potentialLength;
            this.Opacity = 100;
            this.addMode = false;
        }

        //visually shows you cant click certain times
        public void greyOut()
        {
            this.Visibility = Visibility.Visible;
            this.addMode = false;
            this.Opacity = 0.8;
            this.enabled = false;
            this.apptBlockBack.Fill = new SolidColorBrush(greyedOutColor);
            this.apptBlockBack.Stroke = new SolidColorBrush(greyedOutColor);
            this.apptBlockText.Text = "";
        }

        //does the block contain an appointment (should probably rename)
        public bool isEnabled()
        {
            return this.enabled;
        }

        //is the block in add mode
        public bool isInAddMode()
        {
            return this.addMode;
        }

        public Appointment getApptRepresenting()
        {
            return this.apptRepresenting;
        }

        public void setApptRepresenting(Appointment newAppt)
        {
            this.apptRepresenting = newAppt;
        }


        //changes the appointment's colour
        public void setApptStatus(string apptStatus)
        {
            this.apptStatus = apptStatus;
            if (this.apptRepresenting != null)
            {
                this.apptRepresenting.setApptStatus(apptStatus);
            }
            switch (apptStatus)
            {
                case "Not Arrived":
                    this.baseColor = (Color)ColorConverter.ConvertFromString("#FFE55039");
                    this.highlightColor = (Color)ColorConverter.ConvertFromString("#FFB71540");
                    break;
                case "Waiting":
                    this.baseColor = (Color)ColorConverter.ConvertFromString("#FFF6B93B");
                    this.highlightColor = (Color)ColorConverter.ConvertFromString("#FFe58e26");
                    break;
                case "Being Seen":
                    this.baseColor = (Color)ColorConverter.ConvertFromString("#FF78E08F");
                    this.highlightColor = (Color)ColorConverter.ConvertFromString("#FF079992");
                    break;
                case "Seen":
                    this.baseColor = (Color)ColorConverter.ConvertFromString("#FF60A3BC");
                    this.highlightColor = (Color)ColorConverter.ConvertFromString("#FF0a3d62");
                    break;
                case "Billed":
                    this.baseColor = (Color)ColorConverter.ConvertFromString("#FF4A69BD");
                    this.highlightColor = (Color)ColorConverter.ConvertFromString("#FF0c2461");
                    break;
            }

            this.apptBlockBack.Fill = new SolidColorBrush(baseColor);
            this.apptBlockBack.Stroke = new SolidColorBrush(highlightColor);
        }


        //gets the appointment block's status (probably not needed now that we have the appointment object)
        public string getApptStatus()
        {
            return this.apptStatus;
        }


        //if in add mode, makes the block visible and resize
        //if enabled, block changes colour
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
