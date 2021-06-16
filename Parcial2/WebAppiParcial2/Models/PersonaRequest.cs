using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppiParcial2.Models
{
    public class PersonaRequest
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int CodigoPostal { get; set; }
        public int Latitud { get; set; }
        public int Longitud { get; set; }
        public int TelContacto { get; set; }
    }
}