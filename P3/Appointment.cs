using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    public class Appointment
    {
        private string patientName = "Cool Joe"; //deprecated, use patient.patientname instead
        private string apptType = "Appointment Type 1";
        private string apptStatus = "Being Seen";
        private int apptBlockLength = 3; //length in 30 min blocks
        private Patient patient = null; //placeholder
        private int apptStartBlock = 1; //not really used for loading, just use this to calculate time
        private DateTime apptDate = DateTime.Now; //only used for the patient history future stuff

        //used with binding to show the text in the history/future listboxes
        public string DateAndType
        {
            get;
            set;
        }

        //constructor for creating a new appointment from the new appointment process
        //needs to do some stuff still to calculate time and whatever
        public Appointment(Patient patient, string apptType, string apptStatus, int apptBlockLength, int startBlock, DateTime apptDate)
        {
            this.patient = patient;
            this.apptType = apptType;
            this.apptStatus = apptStatus;
            this.apptBlockLength = apptBlockLength;
            this.apptStartBlock = startBlock;
            this.apptDate = apptDate;
            this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
        }

        //fake constructor for making preset appointments
        //requires a patient to be assigned to it
        /*
         * 0 - Flu shot, Seen, 530 AM - 630 AM, Past
         * 1 - Flu shot, Billed, 800 AM - 830 AM, Past
         * 2 - Routine checkup, Seen, 900 AM - 1000 AM, Past
         * 3 - Broken Bone, Being Seen, 1100 AM - 100 PM, Past
         * 4 - Heart Surgery, Waiting, 130 PM - 400 PM, Future
         * 5 - Broken Bone, Waiting, 100 PM - 300 PM, Future
         * 6 - Head Injury, Not Arrived, 430 PM - 530 PM, Future
         * 7 - Sprain, Not Arrived, 600 PM - 630 PM, Future
         */
        public Appointment(int preset, Patient assignedPatient)
        {
            this.patient = assignedPatient;

            if(preset == 0)
            {
                this.apptType = "Flu Shot";
                this.apptStatus = "Billed";
                this.apptStartBlock = 11;
                this.apptBlockLength = 2;
                this.apptDate = new DateTime(2016, 2, 1);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else if(preset == 1)
            {
                this.apptType = "Flu Shot";
                this.apptStatus = "Billed";
                this.apptStartBlock = 16;
                this.apptBlockLength = 1;
                this.apptDate = new DateTime(2016, 2, 2);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else if( preset == 2)
            {
                this.apptType = "Routine Checkup";
                this.apptStatus = "Seen";
                this.apptStartBlock = 18;
                this.apptBlockLength = 2;
                this.apptDate = new DateTime(2016, 8, 8);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else if (preset == 3)
            {
                this.apptType = "Broken Bone";
                this.apptStatus = "Being Seen";
                this.apptStartBlock = 22;
                this.apptBlockLength = 4;
                this.apptDate = new DateTime(2017, 1, 4);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else if (preset == 4) //overlaps with 5
            {
                this.apptType = "Heart Surgery";
                this.apptStatus = "Waiting";
                this.apptStartBlock = 27;
                this.apptBlockLength = 5;
                this.apptDate = new DateTime(2018, 7, 6);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else if (preset == 5) //overlaps with 4
            {
                this.apptType = "Broken Bone";
                this.apptStatus = "Waiting";
                this.apptStartBlock = 26;
                this.apptBlockLength = 4;
                this.apptDate = new DateTime(2018, 8, 10);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else if (preset == 6)
            {
                this.apptType = "Head Injury";
                this.apptStatus = "Not Arrived";
                this.apptStartBlock = 33;
                this.apptBlockLength = 2;
                this.apptDate = new DateTime(2019, 2, 2);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
            else
            {
                this.apptType = "Sprain";
                this.apptStatus = "Not Arrived";
                this.apptStartBlock = 36;
                this.apptBlockLength = 1;
                this.apptDate = new DateTime(2020, 2, 5);
                this.DateAndType = apptDate.ToString("d MMM yyyy") + " - " + apptType;
            }
        }

        //this guy is just here so i can keep using my placeholder code in daySchedule.cs and patientInfoWindow.ca
        public Appointment()
        {
            this.patient = new Patient(1);
        }

        //returns the patient object this appointment is assigned to
        public Patient getPatient()
        {
            return this.patient;
        }

        //gets the associated patient's name
        public string getPatientName()
        {
            return patient.PatientName;
        }

        //gets the appointment type
        public string getApptType()
        {
            return apptType;
        }

        //gets the appointment status
        public string getApptStatus()
        {
            return apptStatus;
        }

        //sets the appointment status
        public void setApptStatus(string apptStatus)
        {
            this.apptStatus = apptStatus;
        }

        //gets the length in blocks of the appointment
        public int getApptBlockLength()
        {
            return apptBlockLength;
        }

        //get the date of this appointment
        public DateTime getDate()
        {
            return this.apptDate;
        }

        //returns the block this appointment starts in
        public int getStartBlock()
        {
            return this.apptStartBlock;
        }

        public new string ToString()
        {
            return "Hello its me!";
        }
    }
}
