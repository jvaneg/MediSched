using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    public class Doctor
    {
        public int ID
        {
            get;
            set;
        }
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

        private int startBlock = 10; //placeholders, every block in 30 mins, starting at block zero
        private int endBlock = 44; //placeholders


        //gets the first block the doctor works in on a day
        public int getStartBlock()
        {
            return this.startBlock;
        }

        //gets the last block the doctor works in on a day
        public int getEndBlock()
        {
            return this.endBlock;
        }

        //returns whether on not the doctor works on this day of the week
        public bool worksOn(int dayOfWeek)
        {
            //placeholder
            if (dayOfWeek == 0 || dayOfWeek == 6) //sunday or saturday -- from our research
            {
                return false;
            }
            else
            {
                return true;
            }
        }

       /* public static ObservableCollection<Doctor> getDoctor()
        {
            var doctor = new ObservableCollection<Doctor>();
            doctor.Add(new Doctor() { Name = "Arshe D", Days = "MTWR", Hours = "8:00 20:30" });
            doctor.Add(new Doctor() { Name = "Philli P", Days = "W", Hours = "1:00 10:00" });
            return doctor;
        }
        */

    }
}
