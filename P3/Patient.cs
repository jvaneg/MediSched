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

        //fake constructor that builds preset patients
        /* 1 - Cool Joey preset
         * 2 - Deputy Arsh preset
         * 3 - Stone Cold Sam preset
         */
        public Patient(int preset)
        {
            if(preset == 1)
            {
                this.PatientNo = 1;
                this.PatientName = "Cool Joey";
                this.email = "cool@joey.website";
                this.address = "2222 22nd Street NW";
                this.city = "Calgary";
                this.province = "Alberta";
                this.country = "Canada";
                this.phone = "403-867-5309";
                this.age = "old";
                this.bloodType = "A+";
                this.billAddress = "3333 Bill Ave SE";
                this.billCity = "Vancouver";
                this.billProvince = "BC";
                this.billCountry = "Canada";
                this.billPhone = "111-111-1111";
                this.billPostal = "T2GG4G";
            }
            else if(preset == 2)
            {
                this.PatientNo = 2;
                this.PatientName = "Deputy Arsh";
                this.email = "arsh@hello.website";
                this.address = "4444 44th Street NW";
                this.city = "Calgary";
                this.province = "Alberta";
                this.country = "Canada";
                this.phone = "403-865-5309";
                this.age = "300";
                this.bloodType = "O-";
                this.billAddress = "9999 Bill Ave SE";
                this.billCity = "Winnipeg";
                this.billProvince = "Manitoba";
                this.billCountry = "Canada";
                this.billPhone = "222-222-2222";
                this.billPostal = "D3D D5D";

                //put appointments for this preset here
            }
            else
            {
                this.PatientNo = 3;
                this.PatientName = "Stone Cold Sam";
                this.email = "scsam@hello.website";
                this.address = "8888 The Ring Street NW";
                this.city = "Calgary";
                this.province = "Alberta";
                this.country = "Canada";
                this.phone = "403-865-9999";
                this.age = "5";
                this.bloodType = "O+";
                this.billAddress = "7777 Bill Ave SE";
                this.billCity = "Winnipeg";
                this.billProvince = "Manitoba";
                this.billCountry = "Canada";
                this.billPhone = "222-222-2222";
                this.billPostal = "D3D D5D";

                //put appointments here
            }
        }



        //adds a new appointment to the patient
        public void addAppointment(Appointment newAppt)
        {
            this.appointments.Add(newAppt);
            this.appointments.Sort((x, y) => x.getDate().CompareTo(y.getDate()));
        }

        //removes an appointment from the list
        public void removeAppointment(Appointment appt)
        {
            this.appointments.Remove(appt);
        }
        
        //gets the list of appointments associated with the patient
        public List<Appointment> getAppointments()
        {
            return this.appointments;
        }
       
    }

}
