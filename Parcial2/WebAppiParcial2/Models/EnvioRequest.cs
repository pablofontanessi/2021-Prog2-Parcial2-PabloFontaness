using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppiParcial2.Models
{
    public class EnvioRequest
    {
        public String DescripcionPaquete { get; set; }
        public int  DniDestinatario { get; set; }        
        public DateTime FechaEstimoEntrega { get; set; }
     
        public static Envios Conversor(EnvioRequest envioRequest)
        {
            Envios envios = new Envios(envioRequest.DescripcionPaquete, envioRequest.DniDestinatario, envioRequest.FechaEstimoEntrega);
            return envios;
        }
    }
}