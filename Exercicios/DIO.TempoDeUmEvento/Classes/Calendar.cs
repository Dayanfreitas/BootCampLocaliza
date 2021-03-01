using System;

namespace DIO.TempoDeUmEvento
{
    public class Calendar
    {
        public Event e;
        public Calendar (Event e) 
        {
            this.e = e;
        }

        public TimeSpan GoToDay () 
        {
            string[] startTime = e.horarioInicio.Split(":");
            string[] endTime = e.horarioFim.Split(":");

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            DateTime starDate = new DateTime(currentYear, currentMonth, e.diaInicio, int.Parse(startTime[0]), int.Parse(startTime[1]), int.Parse(startTime[2]));
            DateTime endDate = new DateTime(currentYear, currentMonth, e.diaFim, int.Parse(endTime[0]), int.Parse(endTime[1]), int.Parse(endTime[2]));
            TimeSpan interval =  endDate - starDate;
            
            return interval;
        }
    }
}