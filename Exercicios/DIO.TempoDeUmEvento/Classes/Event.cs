namespace DIO.TempoDeUmEvento
{
    public class Event
    {
        public int diaInicio = 0;
        public int diaFim = 0;
        public string horarioInicio = "";
        public string horarioFim = "";

        public Event (int diaInicio, int diaFim, string horarioInicio, string horarioFim)
        {
            this.diaInicio = diaInicio;
            this.diaFim = diaFim;
            this.horarioInicio = horarioInicio;
            this.horarioFim = horarioFim;
        }

    }
}