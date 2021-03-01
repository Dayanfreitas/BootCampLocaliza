using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DIO.ComunicacaoEmPiralandia
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            MatchCollection codigo = Regex.Matches(n, "[0-9]");
            List<string> lstring = new List<string>();

            for(int i=0;i < codigo.Count; i++) 
            {
                lstring.Add(codigo[i].Value);
            }
        
            lstring.Reverse();
            foreach (string el in lstring)
            {
                Console.Write($"{el}");
            }
        }
    }
}
