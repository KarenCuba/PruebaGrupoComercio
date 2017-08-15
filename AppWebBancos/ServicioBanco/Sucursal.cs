using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioBanco
{
    public class Sucursal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdBanco { get; set; }
    }
}