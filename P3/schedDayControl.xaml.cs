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
        private ApptBlockControl[] apptBlocks = null;
        private DaySchedule daySched = null;
        private Patient patient = null; //for add mode
        private string apptType = ""; //for add mode
        private int potentialLength = 1;
        private int startBlock = 0;
        private DateTime time = DateTime.Now;

        //loading a day schedule for add mode
        public SchedDayControl(Doctor doctor, DaySchedule daySchedule, int potentialLength, string apptType, Patient patient, DateTime time)
        {
            InitializeComponent();
            Appointment appt = null;
            this.daySched = daySchedule;
            this.doctorNameBlock.Text = doctor.Name;
            this.patient = patient;
            this.time = time;
            this.apptType = apptType;
            this.potentialLength = potentialLength;
            int startBlock = doctor.getStartBlock();
            int endBlock = doctor.getEndBlock();

            this.apptBlocks = new ApptBlockControl[] {this.apptBlock1, this.apptBlock2, this.apptBlock3, this.apptBlock4, this.apptBlock5, this.apptBlock6,
                                                        this.apptBlock7, this.apptBlock8, this.apptBlock9, this.apptBlock10, this.apptBlock11, this.apptBlock12,
                                                        this.apptBlock13, this.apptBlock14, this.apptBlock15, this.apptBlock16, this.apptBlock17, this.apptBlock18,
                                                        this.apptBlock19, this.apptBlock20, this.apptBlock21, this.apptBlock22, this.apptBlock23, this.apptBlock24,
                                                        this.apptBlock25, this.apptBlock26, this.apptBlock27, this.apptBlock28, this.apptBlock29, this.apptBlock30,
                                                        this.apptBlock31, this.apptBlock32, this.apptBlock33, this.apptBlock34, this.apptBlock35, this.apptBlock36,
                                                        this.apptBlock37, this.apptBlock38, this.apptBlock39, this.apptBlock40, this.apptBlock41, this.apptBlock42,
                                                        this.apptBlock43, this.apptBlock44, this.apptBlock45, this.apptBlock46, this.apptBlock47, this.apptBlock48};

            setSchedDays(potentialLength, patient.PatientName, apptType);
            foreach (ApptBlockControl apptBlock in this.apptBlocks)
            {
                apptBlock.MouseLeftButtonDown += ApptBlock_MouseLeftButtonDown;
            }

            //disable times doctor doesnt work
            //start of day
            for(int i = 0; i < startBlock; i++)
            {
                apptBlocks[i].disableAddMode();
                apptBlocks[i].greyOut();
                apptBlocks[i].MouseLeftButtonDown += ApptBlock_DisableMouseDown;
            }

            //end of day
            for(int i = endBlock + 1; i < apptBlocks.Length; i++)
            {
                apptBlocks[i].disableAddMode();
                apptBlocks[i].greyOut();
                apptBlocks[i].MouseLeftButtonDown += ApptBlock_DisableMouseDown;
            }

            //disable putting too close to end of day
            int n = endBlock;
            for(int j = potentialLength - 1; (j > 0) && (n > 0); j--)
            {
                apptBlocks[n].disableAddMode();
                //apptBlocks[n].greyOut();
                //apptBlocks[n].MouseLeftButtonDown += ApptBlock_DisableMouseDown;
                n--;
            }

            //disable adding to times that appointments are already in
            for (int i = 0; i < apptBlocks.Length; i++)
            {
                appt = daySchedule.getAppointmentAtTime(i);
                if (appt != null)
                {
                    apptBlocks[i].loadAppointment(appt);

                    //disable blocks before appointment so that overlapping appointments cant be placed
                    int k = i - 1;
                    for(int j = potentialLength - 1; (j > 0) && (k > 0); j--)
                    {
                        if(apptBlocks[k].isInAddMode())
                        {
                            apptBlocks[k].disableAddMode();
                            //apptBlocks[k].greyOut();
                            //apptBlocks[k].MouseLeftButtonDown += ApptBlock_DisableMouseDown;
                        }
                        k--;
                    }

                    //disable next [size of appointment in blocks - 1] blocks
                    i++;
                    for(int j = 1; (j < appt.getApptBlockLength()) && (i < apptBlocks.Length); j++)
                    {
                        apptBlocks[i].disableAddMode();
                        i++;
                    }
                }
            }
        }


        //loading a day schedule for view mode or main menu
        public SchedDayControl(Doctor doctor, DaySchedule daySchedule)
        {
            InitializeComponent();
            Appointment appt = null;
            this.daySched = daySchedule;
            this.doctorNameBlock.Text = doctor.Name;
            int startBlock = doctor.getStartBlock();
            int endBlock = doctor.getEndBlock();

            this.apptBlocks = new ApptBlockControl[] {this.apptBlock1, this.apptBlock2, this.apptBlock3, this.apptBlock4, this.apptBlock5, this.apptBlock6,
                                                        this.apptBlock7, this.apptBlock8, this.apptBlock9, this.apptBlock10, this.apptBlock11, this.apptBlock12,
                                                        this.apptBlock13, this.apptBlock14, this.apptBlock15, this.apptBlock16, this.apptBlock17, this.apptBlock18,
                                                        this.apptBlock19, this.apptBlock20, this.apptBlock21, this.apptBlock22, this.apptBlock23, this.apptBlock24,
                                                        this.apptBlock25, this.apptBlock26, this.apptBlock27, this.apptBlock28, this.apptBlock29, this.apptBlock30,
                                                        this.apptBlock31, this.apptBlock32, this.apptBlock33, this.apptBlock34, this.apptBlock35, this.apptBlock36,
                                                        this.apptBlock37, this.apptBlock38, this.apptBlock39, this.apptBlock40, this.apptBlock41, this.apptBlock42,
                                                        this.apptBlock43, this.apptBlock44, this.apptBlock45, this.apptBlock46, this.apptBlock47, this.apptBlock48};

            //disable times doctor doesnt work
            //start of day
            for (int i = 0; i < startBlock; i++)
            {
                //apptBlocks[i].disableAddMode();
                apptBlocks[i].greyOut();
               // apptBlocks[i].MouseLeftButtonDown += ApptBlock_DisableMouseDown;
            }

            //end of day
            for (int i = endBlock + 1; i < apptBlocks.Length; i++)
            {
                //apptBlocks[i].disableAddMode();
                apptBlocks[i].greyOut();
                //apptBlocks[i].MouseLeftButtonDown += ApptBlock_DisableMouseDown;
            }

            for (int i = 0; i < apptBlocks.Length; i++)
            {
                appt = daySchedule.getAppointmentAtTime(i);
                if(appt != null)
                {
                    apptBlocks[i].loadAppointment(appt);
                    apptBlocks[i].MouseLeftButtonDown += ApptBlock_MouseLeftButtonDown;
                }
            }
        }


        //event for clicking the appointment block
        private void ApptBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ApptBlockControl apptBlock = (ApptBlockControl)sender;
            if (apptBlock.isEnabled())
            {
                ApptWindow apptWindow = new ApptWindow(apptBlock, apptBlock.getApptRepresenting());
                apptWindow.Owner = Window.GetWindow(this);
                apptWindow.Show();
            }
            else
            {
                //save and close
                string apptStatus = "Not Arrived";
                apptBlock.setApptRepresenting(new Appointment(patient, apptType, apptStatus, potentialLength, this.startBlock, this.time)); //saves the appointment to the block (probably dont need this)
                daySched.setAppointmentAtTime(apptBlock.getApptRepresenting(), Array.IndexOf(apptBlocks, apptBlock)); //save the appointment to the schedule

                //add the appointment to the patient as well
                this.patient.addAppointment(apptBlock.getApptRepresenting());

                //MessageBox.Show("SAVED");
                Window.GetWindow(this).Close();

                //force the windows to update
                MediSchedData.forceRefresh();
            }
        }

        //disables clicking on a block
        private void ApptBlock_DisableMouseDown(object sender, MouseButtonEventArgs e)
        {
            //deliberately do nothing
        }

        //Activates the schedule blocks
        private void setSchedDays(int potentialLength, string patientName, string apptType)
        {

            foreach (ApptBlockControl apptBlock in this.apptBlocks)
            {
                apptBlock.setupAddMode(potentialLength, patientName, apptType);
            }
        }

    }
}
