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

        //sets up the fake db
        public static void setUpFakeDb()
        {
            //addDocToList("Dr A", "MWF", "placeholder"); //placeholder
            //addDocToList("Dr B", "MWF", "placeholder"); //placeholder
            //addDocToList("Dr C", "MWF", "placeholder"); //placeholder

            addDocToList(new Doctor() { Name = "Dr A", Days = "MWF", Hours = "1:20-2:20"}); //placeholder
            addDocToList(new Doctor() { Name = "Dr B", Days = "MWF", Hours = "1:20-2:20" }); //placeholder
            addDocToList(new Doctor() { Name = "Dr C", Days = "MWF", Hours = "1:20-2:20" }); //placeholder
        }

        //triggers when the db changes
        public static event EventHandler dbChanged = delegate {};

        public static List<Doctor> getDocList()
        {
            return docList;
        }

        //public static void addDocToList(string docName, string workingdays, string workingTime)
        public static void addDocToList(Doctor newDoc)
        {
            //docList.Add(new Doctor() { Name = docName, Days = workingdays, Hours = workingTime });
            docList.Add(newDoc);
            dbChanged(null, null); //im sorry this is so janky, triggers the dbChanged event
        }

        //gets the doctor's schedule for this day
        public static DaySchedule getDaySchedule(Doctor doctor, int year, int month, int day)
        {
            //placeholder return
            return new DaySchedule();
        }

        /* 
         * Called when doctor is to be deleted
         * ID: doctor's ID
         */
        public static void deleteDoc(int ID)
        {
            for (int i = 0; i < docList.Count; i++)
            {
                
                if (docList[i].ID == ID)
                {
                    docList.RemoveAt(i);
                    break;
                }
            }
            dbChanged(null, null);
        }

        /*
         * Called when doctor info is updated
         * ID: doctor's id
         * Name: updated doctor's name
         * Hours: updated doctor's hours
         * Days: updated doctor's days
         */
        internal static void updateDocInfo(int ID, string name, string hours, string days)
        {
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
            dbChanged(null, null);
        }
    }
}
