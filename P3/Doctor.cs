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

        //the real constructor
        public Doctor(string docName, string days, string hours)
        {
            this.ID = 0; //actually unused but i dont really care to remove everything referencing this
            this.Name = docName;
            this.Days = days;
            this.Hours = hours;

            parseHours(hours);
        }

        //turns hours as a string into start block and end block
        private void parseHours(string hoursText)
        {
            this.startBlock = 1; //placeholder
            this.endBlock = 47; //placeholder
        }


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
            bool worksOnThisDay = false;

            if (dayOfWeek == 0 || dayOfWeek == 6) //sunday or saturday -- from our research
            {
                worksOnThisDay = false;
            }
            else
            {
                switch(dayOfWeek)
                {
                    case 1: //monday
                        worksOnThisDay = this.Days.Contains("M");
                        break;
                    case 2: //tuesday
                        worksOnThisDay = this.Days.Contains("T");
                        break;
                    case 3: //wednesday
                        worksOnThisDay = this.Days.Contains("W");
                        break;
                    case 4: //thursday
                        worksOnThisDay = this.Days.Contains("R");
                        break;
                    case 5: //friday
                        worksOnThisDay = this.Days.Contains("F");
                        break;
                }
            }

            return worksOnThisDay;
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
