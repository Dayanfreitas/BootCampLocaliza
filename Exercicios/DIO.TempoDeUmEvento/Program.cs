using System;

namespace DIO.TempoDeUmEvento
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] startDay = Console.ReadLine().Split(" ");
            string startTime = Console.ReadLine();
            
            string[] endDay = Console.ReadLine().Split(" ");
            string endTime = Console.ReadLine();

            Event e = new Event(int.Parse(startDay[1]), int.Parse(endDay[1]), startTime, endTime);
            Calendar calendar = new Calendar(e);
            TimeSpan interval = calendar.GoToDay();

            Console.WriteLine($"{interval.Days} dia(s)");
            Console.WriteLine($"{interval.Hours} hora(s)");
            Console.WriteLine($"{interval.Minutes} minuto(s)");
            Console.WriteLine($"{interval.Seconds} segundo(s)");
        }
    }
}
