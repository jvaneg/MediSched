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
        private Patient patient = new Patient() { PatientName = "Arsho", PatientNo = 2 };
        private int apptStartBlock = 1; //not really used for loading, just use this to calculate time

        //constructor for creating a new appointment from the new appointment process
        //needs to do some stuff still to calculate time and whatever
        public Appointment(Patient patient, string apptType, string apptStatus, int apptBlockLength, int startBlock)
        {
            this.patient = patient;
            this.apptType = apptType;
            this.apptStatus = apptStatus;
            this.apptBlockLength = apptBlockLength;
            this.apptStartBlock = startBlock;
        }

        //this guy is just here so i can keep using my placeholder code in daySchedule.cs
        public Appointment()
        {

        }


        public string getPatientName() //change this to use patient.getname
        {
            return patient.PatientName;
        }

        public string getApptType()
        {
            return apptType;
        }

        public string getApptStatus()
        {
            return apptStatus;
        }

        public void setApptStatus(string apptStatus)
        {
            this.apptStatus = apptStatus;
        }

        public int getApptBlockLength()
        {
            return apptBlockLength;
        }
    }
}
