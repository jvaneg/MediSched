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

        private int startBlock; //placeholders, every block in 30 mins, starting at block zero
        private int endBlock; //placeholders

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
        public void parseHours(string hoursText)
        {
            startBlock = this.doctorStartBlockFormat(hoursText);
            endBlock = this.doctorEndBlockFormat(hoursText);

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

        // Takes doctor's working hours input in format "AB:CD{AM/PM}-EF:GH{AM/PM}" and returns the int value of the start block . Only 1 of AB or EF are required
        public int doctorStartBlockFormat(string doctorTime)
        {
            int startVal = 0;

            int indexDash = doctorTime.IndexOf("-");
            int indexFirstColon = doctorTime.IndexOf(":");

            string frontHour = doctorTime.Substring(0, indexFirstColon);
            string frontMinutes = doctorTime.Substring(indexFirstColon + 1, 2);
            string morningOrNight = doctorTime.Substring(indexDash - 2, 2);

            int i;
            if (frontMinutes != "00")
            {
                if (Int32.TryParse(frontMinutes, out i))
                {
                    if (Int32.Parse(frontMinutes) <= 30)
                    {
                        startVal += 1;
                    }
                    else
                    {
                        startVal += 2;
                    }
                }
            }

            switch (frontHour)
            {
                case "12":
                    break;

                case "1":
                    startVal += 2;
                    break;

                case "2":
                    startVal += 4;
                    break;

                case "3":
                    startVal += 6;
                    break;

                case "4":
                    startVal += 8;
                    break;

                case "5":
                    startVal += 10;
                    break;

                case "6":
                    startVal += 12;
                    break;

                case "7":
                    startVal += 14;
                    break;

                case "8":
                    startVal += 16;
                    break;

                case "9":
                    startVal += 18;
                    break;

                case "10":
                    startVal += 20;
                    break;

                case "11":
                    startVal += 22;
                    break;
            }

            if (morningOrNight == "PM")
            {
                startVal += 24;
            }

            if (startVal > 47)
            {
                startVal = 47;
            }

            return startVal;
        }

        // Takes doctor's working hours input in format "AB:CD{AM/PM}-EF:GH{AM/PM}" and returns the int value of the end block . Only 1 of AB or EF are required

        public int doctorEndBlockFormat(string doctorTime)
        {
            int endVal = 0;

            int indexDash = doctorTime.IndexOf("-");
            int indexFirstColon = doctorTime.IndexOf(":");
            int indexSecondColon = doctorTime.IndexOf(":",indexFirstColon+1);

            int singleDigitHourHelp = indexSecondColon - indexDash;
            string backHour;

            if (singleDigitHourHelp == 2)
            {
                backHour = doctorTime.Substring(indexDash + 1, 1);
            } else
            {
                backHour = doctorTime.Substring(indexDash + 1, 2);

            }

            string backMinutes = doctorTime.Substring(indexSecondColon + 1 , 2);
            string morningOrNight = doctorTime.Substring(doctorTime.Length-2);

            int i;
            if (backMinutes != "00")
            {
                if (Int32.TryParse(backMinutes, out i))
                {
                    if (Int32.Parse(backMinutes) >= 30)
                    {
                        endVal += 1;
                    }
                }
            }

            switch (backHour)
            {
                case "12":
                    break;

                case "1":
                    endVal += 2;
                    break;

                case "2":
                    endVal += 4;
                    break;

                case "3":
                    endVal += 6;
                    break;

                case "4":
                    endVal += 8;
                    break;

                case "5":
                    endVal += 10;
                    break;

                case "6":
                    endVal += 12;
                    break;

                case "7":
                    endVal += 14;
                    break;

                case "8":
                    endVal += 16;
                    break;

                case "9":
                    endVal += 18;
                    break;

                case "10":
                    endVal += 20;
                    break;

                case "11":
                    endVal += 22;
                    break;
            }

            if (morningOrNight == "PM")
            {
                endVal += 24;
            }

            return endVal - 1;
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

