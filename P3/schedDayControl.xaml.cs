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
    public partial class SchedDayControl : UserControl
    {
        private int potentialLength = 1;
        private bool addMode = false;
        private string patientName = "";
        private string apptType = "";

        //for view mode
        public SchedDayControl(string DoctorName)
        {
            InitializeComponent();
            this.doctorNameBlock.Text = DoctorName;
        }

        //for add mode
        public SchedDayControl(string DoctorName, int potentialLength, string patientName, string apptType)
        {
            InitializeComponent();
            this.doctorNameBlock.Text = DoctorName;
            setSchedDays(potentialLength, patientName, apptType);

        }

        private void setSchedDays(int potentialLength, string patientName, string apptType)
        {
            this.apptBlock1.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock2.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock3.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock4.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock5.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock6.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock7.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock8.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock9.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock10.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock11.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock12.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock13.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock14.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock15.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock16.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock17.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock18.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock19.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock20.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock21.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock22.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock23.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock24.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock25.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock26.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock27.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock28.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock29.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock30.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock31.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock32.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock33.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock34.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock35.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock36.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock37.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock38.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock39.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock40.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock41.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock42.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock43.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock44.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock45.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock46.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock47.setupAddMode(potentialLength, patientName, apptType);
            this.apptBlock48.setupAddMode(potentialLength, patientName, apptType);
        }

    }
}
