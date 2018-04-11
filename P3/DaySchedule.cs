using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    public class DaySchedule
    {
        /*
        Appointment[] appointments = new Appointment[] { null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null};
        */
        List<Appointment> appointments = new List<Appointment>() { null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null,
                                                         null, null, null, null, null, null};


        //placeholder
        /*
        public DaySchedule()
        {
            //all placeholders right now
            appointments = new Appointment[] { null, new Appointment(), null, null, null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, null, new Appointment(1, new Patient(2)), null,
                                                null, null, null, null, null, null,
                                                null, null, null, new Appointment(), null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, null, null, null,
                                                null, null, null, new Appointment(), null, null};
           
        }
        */

        //creates an empty schedule
        public DaySchedule()
        {
            //intentionally do nothing
        }

        //creates day schedules from presets, requires patients to assign
        public DaySchedule(int preset, List<Patient> patients)
        {
            Appointment appt = null;

            if(preset == 1)
            {
                //Appt 2 for joey
                appt = new Appointment(2, patients[0]);
                patients[0].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 3 for arsh
                appt = new Appointment(3, patients[1]);
                patients[1].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 4 for sam
                appt = new Appointment(4, patients[2]);
                patients[2].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 6 for joey
                appt = new Appointment(6, patients[0]);
                patients[0].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());
            }
            else if(preset == 2)
            {
                //Appt 1 for sam
                appt = new Appointment(1, patients[2]);
                patients[2].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 2 for arsh
                appt = new Appointment(2, patients[1]);
                patients[1].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 5 for joey
                appt = new Appointment(5, patients[0]);
                patients[0].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 7 for arsh
                appt = new Appointment(7, patients[1]);
                patients[1].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());
            }
            else
            {
                //Appt 0 for joey
                appt = new Appointment(0, patients[0]);
                patients[0].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 1 for sam
                appt = new Appointment(1, patients[2]);
                patients[2].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 3 for joey
                appt = new Appointment(3, patients[0]);
                patients[0].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 5 for arsh
                appt = new Appointment(5, patients[1]);
                patients[1].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());

                //Appt 6 for sam
                appt = new Appointment(6, patients[2]);
                patients[2].addAppointment(appt);
                setAppointmentAtTime(appt, appt.getStartBlock());
            }
        }



        //starts at zero
        public Appointment getAppointmentAtTime(int timeBlock)
        {
            return this.appointments[timeBlock];
        }

        //sets an appointment at a specific time
        public void setAppointmentAtTime(Appointment appt, int timeBlock)
        {
            this.appointments[timeBlock] = appt;
        }

        //remove appointment from the 
        public void removeAppointment(Appointment appt)
        {
            if(appointments.IndexOf(appt) != -1)
            {
                appointments[appointments.IndexOf(appt)] = null;
            }   
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
            for(int i = startBlock; i < appointments.Count && i <= endBlock; i++)
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
                    i += appointments[i].getApptBlockLength() - 1;
                }
            }

            return counter;
        }
    }
}
