using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeString
{
    public class ChangeString
    {
        public string build(string cadena)
        {
            //string cadena = "123 abcd*3";
            string CadenaDevuelta = string.Empty;
            cadena = cadena.Replace("a", "b").Replace("c", "d");
            CadenaDevuelta = cadena.Replace("c", "d");
            return CadenaDevuelta;
            //Console.WriteLine(CadenaDevuelta);
        }
    }
}
