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

        List<Appointment> appointments = new List<Appointment>(); //list of appointments


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

        //stub only here temporarily
        public Patient()
        {
            this.PatientName = "Arsho";
            this.PatientNo = 1;
        }       
    }
}
