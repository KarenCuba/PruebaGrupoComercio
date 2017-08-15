using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteRange
{
    class CompleteRange
    {
        string[] First;
        public void Build()
        {
            Console.WriteLine("Ingrese Cadena: ");
            string cadena = Console.ReadLine();
            cadena = cadena.Replace("[", "").Replace("]", "");
            First = new string[cadena.Length];
            First = cadena.Split(',');
            int[] convertedItems = Array.ConvertAll<string, int>(First, int.Parse);

            int ValorMinimo=1;
            int ValorMaximo=1;
            for (int i = 0; i < convertedItems.Length; i++)
            {
                if (i == 0)
                {
                    ValorMaximo = convertedItems[i];
                }
                else {
                    if (ValorMaximo < convertedItems[i])
                    {
                        ValorMaximo = convertedItems[i];
                    }
                }              
            }

            string ResultadoCadena = string.Empty;
            for (int j = ValorMinimo; j <= ValorMaximo; j++)
            {
                if (j < ValorMaximo)
                {
                    ResultadoCadena = ResultadoCadena + j + ",";
                }
                else {
                    ResultadoCadena = ResultadoCadena + j;
                }
                
            }
            ResultadoCadena = "[" + ResultadoCadena + "]";
            Console.WriteLine("Salida: " + ResultadoCadena);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            CompleteRange cr = new CompleteRange();
            cr.Build();
            
        }
    }
}
