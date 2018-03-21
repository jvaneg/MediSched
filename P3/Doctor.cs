using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    class Doctor
    {
        public string Name
        {
            get;
            set;
        }

        public string Days 
        {
            get;
            set;
        }

        public string Hours
        {
            get;
            set;
        }

        public static ObservableCollection<Doctor> getDoctor()
        {
            var doctor = new ObservableCollection<Doctor>();
            doctor.Add(new Doctor() { Name = "Arshe D", Days = "MTWR", Hours = "8:00 20:30" });
            doctor.Add(new Doctor() { Name = "Philli P", Days = "W", Hours = "1:00 10:00" });
            return doctor;
        }

    }
}
