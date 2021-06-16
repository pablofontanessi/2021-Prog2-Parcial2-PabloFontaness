using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppiParcial2.Models
{
    public class EnvioResponse
    {
        public EnvioResponse(string id)
        {
            this.NumeroGenerado = id;
        }

        public string NumeroGenerado { get; set; }
    }
}