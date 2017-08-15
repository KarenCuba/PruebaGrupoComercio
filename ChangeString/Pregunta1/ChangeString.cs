using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pregunta1
{
    class ChangeString
    {
        string cadena;
        public void build()
        {
            Console.WriteLine("Ingrese Cadena: ");
            cadena = Console.ReadLine();
        }

        public void resultado()
        {
            string CadenaDevuelta = string.Empty;
            CadenaDevuelta = cadena.Replace("a", "b").Replace("c", "d");
            Console.WriteLine("Salida: " + CadenaDevuelta);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            ChangeString cs = new ChangeString();
            cs.build();
            cs.resultado();
          
        }
    }
}
