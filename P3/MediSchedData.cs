using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P3
{

    public static class MediSchedData
    {
        private static List<Doctor> docList = new List<Doctor>();
        private static List<Patient> patientList = new List<Patient>();
        private static Dictionary<Doctor, List<DaySchedule>> daySchedules = new Dictionary<Doctor, List<DaySchedule>>(); 

        //sets up the fake db
        public static void setUpFakeDb()
        {
            //generate sample doctors
            docList.Add(new Doctor("Dr van Egmond", "MTWF", "3:00AM-11:00PM"));
            docList.Add(new Doctor("Dr Niu", "MWF", "3:00AM-11:00PM"));
            docList.Add(new Doctor("Dr Dhillon", "MWRF", "3:00AM-11:00PM"));

            //generate sample patients
            addPatientToList(new Patient(1)); //preset patients
            addPatientToList(new Patient(2)); //preset patients
            addPatientToList(new Patient(3)); //preset patients

            //add doctors to <doctor, dayschedule list> hashtable
            foreach( Doctor doc in docList)
            {
                daySchedules.Add(doc, new List<DaySchedule>());
            }

            //add preset day schedules to the doctors
            //doc 1 gets 1 2 3
            daySchedules[docList[0]].Add(new DaySchedule(1, patientList));
            daySchedules[docList[0]].Add(new DaySchedule(2, patientList));
            daySchedules[docList[0]].Add(new DaySchedule(3, patientList));
            //doc 2 gets 3 1 2
            daySchedules[docList[1]].Add(new DaySchedule(3, patientList));
            daySchedules[docList[1]].Add(new DaySchedule(1, patientList));
            daySchedules[docList[1]].Add(new DaySchedule(2, patientList));
            //doc 3 gets 2 3 1
            daySchedules[docList[2]].Add(new DaySchedule(2, patientList));
            daySchedules[docList[2]].Add(new DaySchedule(3, patientList));
            daySchedules[docList[2]].Add(new DaySchedule(1, patientList));


        }

        //triggers when the db changes
        public static event EventHandler dbChanged = delegate { };

        public static List<Doctor> getDocList()
        {
            return docList;
        }

        public static List<Patient> getPatientList()
        {
            return patientList;
        }

        //public static void addDocToList(string docName, string workingdays, string workingTime)
        public static void addDocToList(Doctor newDoc)
        {
            //docList.Add(new Doctor() { Name = docName, Days = workingdays, Hours = workingTime });

        
            docList.Add(newDoc);
            daySchedules.Add(newDoc, new List<DaySchedule>());
            daySchedules[newDoc].Add(new DaySchedule());    //add 3 because only 3 days exist
            daySchedules[newDoc].Add(new DaySchedule());
            daySchedules[newDoc].Add(new DaySchedule());
            dbChanged(null, null); //im sorry this is so janky, triggers the dbChanged event
        }

        //gets the doctor's schedule for this day
        //fakes it by just grabbing one of 3 possible days
        //ignores the eyar and month and mods the day by the # of possible schedules
        public static DaySchedule getDaySchedule(Doctor doctor, int year, int month, int day)
        {
            return daySchedules[doctor][day % 3];
        }

        /* 
         * Called when doctor is to be deleted
         */
        public static void deleteDoc(Doctor docToRemove)
        {
            //remove from the doc list
            docList.Remove(docToRemove);

            /*
            for (int i = 0; i < docList.Count; i++)
            {

                if (docList[i].ID == ID)
                {
                    docList.RemoveAt(i);
                    break;
                }
            }
            */

            //remove from the hashtable
            daySchedules.Remove(docToRemove);

            //alert that db has changed
            dbChanged(null, null);
        }

        public static void updateDoc(Doctor docToEdit)
        {

            //dont think this needs to be changed at all

            /*
            for (int i = 0; i < docList.Count; i++)
            {
                if (docList[i].ID == ID)
                {
                    docList[i].Name = name;
                    docList[i].Hours = hours;
                    docList[i].Days = days;
                    break;
                }
            }
            */
            dbChanged(null, null);
        }

        /*
         * Called when doctor info is updated
         * ID: doctor's id
         * Name: updated doctor's name
         * Hours: updated doctor's hours
         * Days: updated doctor's days
         */
        public static void updateDocInfo(int ID, string name, string hours, string days)
        {
            //dont think this needs to be changed at all

            /*
            for (int i = 0; i < docList.Count; i++)
            {
                if (docList[i].ID == ID)
                {
                    docList[i].Name = name;
                    docList[i].Hours = hours;
                    docList[i].Days = days;
                    break;
                }
            }
            */
            dbChanged(null, null);
        }

        //adds a patient to the patient list
        public static void addPatientToList(Patient newPatient)
        {
            patientList.Add(newPatient);
            patientList.Sort((x, y) => x.PatientName.CompareTo(y.PatientName));
            dbChanged(null, null);
        }

        //removes an appointment from the system
        //im glad this isnt a real program cause this is o(n^2) lmao
        public static void deleteAppointment(Appointment apptToDelete)
        {
            //remove from the hashtable
            foreach (List<DaySchedule> schedules in daySchedules.Values)
            {
                foreach(DaySchedule schedule in schedules)
                {
                    schedule.removeAppointment(apptToDelete);
                }
            }

            //remove from patients
            foreach(Patient patient in patientList)
            {
                patient.removeAppointment(apptToDelete);
            }

            dbChanged(null, null);
        }

        //allows other classes to force windows to refresh
        public static void forceRefresh()
        {
            dbChanged(null, null);
        }
    }
}
