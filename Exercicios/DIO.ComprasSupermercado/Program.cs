using System;
using System.Collections.Generic;
using System.Linq;

namespace DIO.ComprasSupermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lProductsLine = new List<string>();
            List<string> lProducts = new List<string>();
            int totalDeCasosDeTeste = int.Parse(Console.ReadLine());
            // int[] listaSize = new int[totalDeCasosDeTeste];

            for (int i = 0; i < totalDeCasosDeTeste; i++)
            {
                string[] lista = Console.ReadLine().Split(" ");
                // listaSize[i] = lista.Length;

                for (int j=0; j < lista.Length; j++)
                {
                    string produtos = lista[j];
                    if (!lProducts.Contains(produtos)) 
                    {
                        lProducts.Add(produtos);
                    }
                }
                lProducts.Sort();
                lProducts.Add(Environment.NewLine);
                lProductsLine.AddRange(lProducts);
                lProducts.Clear();
            }

            foreach(var e in lProductsLine)
            {
                Console.Write(e);
                Console.Write(" ");
            }

        }
    }
}
