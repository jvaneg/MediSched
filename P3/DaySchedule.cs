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
    }
}
