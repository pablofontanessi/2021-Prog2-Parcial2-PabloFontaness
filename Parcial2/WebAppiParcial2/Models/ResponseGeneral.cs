using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppiParcial2.Models
{
    public class ResponseGeneral
    {
        public ResponseGeneral(Respuesta respuesta)
        {
            this.Respuesta = respuesta.Resultado;
            this.id = respuesta.Id;
            this.Detalle = respuesta.Detalle;
        }

        public bool Respuesta { get; set; }
        public int id { get; set; }

        public string Detalle { get; set; }

    }
}