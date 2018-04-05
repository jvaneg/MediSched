using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    public class DaySchedule
    {
        Appointment[] appointments = null;

        public DaySchedule()
        {
            appointments = new Appointment[] { null, new Appointment(), null, null, null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, new Appointment(), null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, new Appointment(), null, null};
           
        }

        //starts at zero
        public Appointment getAppointmentAtTime(int timeBlock)
        {
            return this.appointments[timeBlock];
        }

        public void setAppointmentAtTime(Appointment appt, int timeBlock)
        {
            this.appointments[timeBlock] = appt;
        }


        //gets the number of open appointments for this day
        public int getNumAppointments()
        {
            int counter = 0;
            if(appointments != null)
            {
                foreach( Appointment appt in appointments)
                {
                    if(appt != null)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        //gets the number of open slots of a specified size
        public int getNumSlots(int slotSize, int startBlock, int endBlock)
        {
            int counter = 0;

            int openBlockSizeCounter = 0;
            for(int i = startBlock; i < appointments.Length && i < endBlock; i++)
            {
                if(appointments[i] == null)
                {
                    openBlockSizeCounter++;
                    if(openBlockSizeCounter >= slotSize)
                    {
                        counter++;
                        openBlockSizeCounter = 0;
                    }
                }
                else
                {
                    openBlockSizeCounter = 0;
                    i += appointments[i].getApptBlockLength();
                }
            }

            return counter;
        }
    }
}
