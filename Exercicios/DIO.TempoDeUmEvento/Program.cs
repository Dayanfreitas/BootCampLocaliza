using System;

namespace DIO.TempoDeUmEvento
{
    public enum Compare
    {
        equal = 0,
        larger = 1,
        smaller = -1
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Dia 5 
            // 8 : 10 : 11
            // Dia 6 
            // 8 : 9 : 11

            Event e = new Event(5, 6, "8 : 10 : 11", "8 : 9 : 11");
            int dias = 0;
            int horas = 0;
            int minutos = 0;
            int segundos = 0;

            int compareHorarios = String.Compare(e.horarioInicio, e.horarioFim);
            bool apenasDias = compareHorarios == (int) Compare.equal;

            if (apenasDias) {
                dias = e.diaFim - e.diaInicio;
            }else
            {
                string[] timeInicio = e.horarioInicio.Split(":");
                string[] timeFim    = e.horarioFim.Split(":");
                
                horas = int.Parse(timeInicio[0]) - int.Parse(timeFim[0]);
                minutos = int.Parse(timeInicio[1]) - int.Parse(timeFim[1]);
                segundos = int.Parse(timeInicio[2]) - int.Parse(timeFim[2]);

                Console.WriteLine("horas: {0}", horas);
                Console.WriteLine("m:{0}", minutos);
                Console.WriteLine("s: {0}", segundos);

                // Console.ReadLine();

                // horas = int.Parse(timeInicio[0]) - int.Parse(timeFim[0]);
                // minutos  = int.Parse(timeInicio[1]) - int.Parse(timeFim[1]);
                // segundos = int.Parse(timeInicio[2]) - int.Parse(timeFim[2]);
                if (horas < 0) 
                {
                    horas *= -1 ;
                    // horas =  horas - 24;
                }
                if (minutos < 0) 
                {
                    minutos *= -1;
                    // minutos = minutos - 60;
                }
                if (segundos < 0) 
                {
                    segundos*= -1;
                    // segundos -= 60;
                }

                // Console.WriteLine($"-----------------> INICIO");
                // Console.WriteLine($"{timeInicio[0]} hora(s)");
                // Console.WriteLine($"{timeInicio[1]} minuto(s)");
                // Console.WriteLine($"{timeInicio[2]} segundo(s)");

                // Console.WriteLine($"-----------------> FIM");
                // Console.WriteLine($"{timeFim[0]} hora(s)");
                // Console.WriteLine($"{timeFim[1]} minuto(s)");
                // Console.WriteLine($"{timeFim[2]} segundo(s)");
                
            }

            Console.WriteLine($"{dias} dia(s)");
            Console.WriteLine($"{horas} hora(s)");
            Console.WriteLine($"{minutos} minuto(s)");
            Console.WriteLine($"{segundos} segundo(s)");
        }

        
    }
}
