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

        public new string ToString()
        {
            return "Hello its me!";
        }
    }
}
