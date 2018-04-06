using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P3
{
    public class Patient
    {
        public int PatientNo
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }

        public string email = "";
        public string address = "";
        public string city = "";
        public string province = "";
        public string country = "";
        public string phone = "";
        public string age = "";
        public string bloodType = "";
        public string billAddress = "";
        public string billCity = "";
        public string billProvince = "";
        public string billCountry = "";
        public string billPhone = "";
        public string billPostal = "";

        private List<Appointment> appointments = new List<Appointment>(); //list of appointments


        //real patient constructor
        public Patient(string name, string email, string address, string city, string province, string country, string phone, string age, string bloodType, string billAddress, string billCity, string billProvince, string billCountry, string billPhone, string billPostal)
        {
            this.PatientName = name;
            this.email = email;
            this.address = address;
            this.city = city;
            this.province = province;
            this.country = country;
            this.phone = phone;
            this.age = age;
            this.bloodType = bloodType;
            this.billAddress = billAddress;
            this.billCity = billCity;
            this.billProvince = billProvince;
            this.billCountry = billCountry;
            this.billPhone = billPhone;
            this.billPostal = billPostal;
        }

        //stub only here temporarily for testing, being called from the two patient select search spots
        public Patient()
        {
            this.PatientName = "Arsho2";
            this.PatientNo = 1;
            this.appointments.Add(new Appointment(this, "Appt Type 1", "Not Arrived", 3, 5, new DateTime(2050,1,1))); //test stuff
        }

        //fake constructor get rid of me once everything works
        public Patient(int fake)
        {
            this.PatientName = "Arsho";
            this.PatientNo = 1;
        }

        //adds a new appointment to the patient
        public void addAppointment(Appointment newAppt)
        {
            this.appointments.Add(newAppt);
        }
        
        //gets the list of appointments associated with the patient
        public List<Appointment> getAppointments()
        {
            return this.appointments;
        }
       
    }

}
