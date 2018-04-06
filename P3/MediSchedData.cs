using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    
    public static class MediSchedData
    {
        private static List<Doctor> docList = new List<Doctor>();
        private static List<Patient> patientList = new List<Patient>();

        //sets up the fake db
        public static void setUpFakeDb()
        {
            addDocToList("Dr A", "MWF", "placeholder"); //placeholder
            addDocToList("Dr B", "MWF", "placeholder"); //placeholder
            addDocToList("Dr C", "MWF", "placeholder"); //placeholder
        }

        //triggers when the db changes
        public static event EventHandler dbChanged = delegate {};

        public static List<Doctor> getDocList()
        {
            return docList;
        }

        public static void addDocToList(string docName, string workingdays, string workingTime)
        {
            docList.Add(new Doctor() { Name = docName, Days = workingdays, Hours = workingTime });
            dbChanged(null, null); //im sorry this is so janky, triggers the dbChanged event
        }

        //gets the doctor's schedule for this day
        public static DaySchedule getDaySchedule(Doctor doctor, int year, int month, int day)
        {
            //placeholder return
            return new DaySchedule();
        }
        
        //add a new patient to the list
        public static void addPatientToList(Patient newPatient)
        {
            patientList.Add(newPatient);
        }
    }
}
