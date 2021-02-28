using System;
using System.Collections.Generic;

namespace DIO.CrescimentoPopulacional
{

    public class Populacao 
    {
        public int p;
        public double TaxaCrescimento;

        public Populacao (int p, double taxaCrescimento) {
            this.p = p;
            this.TaxaCrescimento = taxaCrescimento;
        }

        public void CalculateGrowth () 
        {
            int aumento = (int) (this.p * this.TaxaCrescimento/100);
            this.p += aumento;
        }

        public override string ToString()
        {
            return "População: " + this.p + " Taxa de crescimento: " + this.TaxaCrescimento;
        }
    }

    public class PopulationAnalyzer
    {
        public List<Populacao> populationList = new List<Populacao>();
        
        public PopulationAnalyzer(List<Populacao> populationList) 
        {
            this.populationList = populationList;
        }

        public string AnalyzeNextYear (Populacao p1, Populacao p2) 
        {   
            int year = 0;
            if (p1.TaxaCrescimento < 1.0) {
                return "Mais de 1 seculo.";
            }

            while (p1.p <= p2.p) {
                year++;
                p1.CalculateGrowth();
                p2.CalculateGrowth();
            }
            
            if (year > 100) {
                return "Mais de 1 seculo.";
            }else {
                return year+" anos.";
            }
            return "true";

        }

        public override string ToString()
        {
            string r = "";
            int index = 0;
            foreach (var p in populationList) 
            {
                r += "# "+ index + " " + p.ToString(); 
                index++;
            }

            return r; 
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            List<Populacao> l = inputUser();
            PopulationAnalyzer pA = new PopulationAnalyzer(l);
            for (int i=0; i < l.Count; i+=2)
            { 
                Populacao p1 = l[i];
                Populacao p2 = l[i+1];
                Console.WriteLine(pA.AnalyzeNextYear(p1, p2));
            }
        }

        private static List<Populacao> inputUser()
        {
            List<Populacao> populationList = new List<Populacao>();
            int t = Convert.ToInt32(Console.ReadLine());
            int pa, pb;
            double ca, cb;

            for (int i = 0; i < t; i++)
            {
                string[] valores = Console.ReadLine().Split();
                pa = int.Parse(valores[0]);
                pb = int.Parse(valores[1]);
                ca = double.Parse(valores[2]);
                cb = double.Parse(valores[3]);

                Populacao pA = new Populacao(pa, ca);
                Populacao pB = new Populacao(pb, cb);
                populationList.Add(pA);
                populationList.Add(pB);
            }

            return populationList;
        }

    }
}
