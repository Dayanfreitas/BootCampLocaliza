using System;

namespace PinkCelebro
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lm = new int[4] { 2, 3, 4 , 5};
            int casosDeTeste = int.Parse(Console.ReadLine());      
            int[] entradas = Convert(Console.ReadLine().Split(" "));
            
            for (int i = 0; i < lm.Length;i++)
            {
                int lmn = lm[i];
                int numerosDeMultiplos = 0;
                for (int j = 0; j < entradas.Length;j++)
                {
                    if (entradas[j] % lmn == 0) {
                        numerosDeMultiplos++;                        
                    }
                }
                Console.WriteLine($"{numerosDeMultiplos} Multiplo(s) de {lmn}");
            }

        }


        private static int[] Convert(string[] arr)
        {
            int[] r = new int[arr.Length];

            for (int i=0; i < arr.Length; i++)
            {
                r[i] = System.Convert.ToInt32(arr[i]);
            }

            return r;
        }
    }
}
