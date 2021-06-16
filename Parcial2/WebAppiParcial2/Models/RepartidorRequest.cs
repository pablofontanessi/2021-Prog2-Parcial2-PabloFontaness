using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppiParcial2.Models
{
   
    public class RepartidorRequest : PersonaRequest
    {
        public RepartidorRequest()
        {
        }

        public RepartidorRequest(Repartidor repartidor)
        {
            this.Dni = repartidor.Dni;
            this.Nombre = repartidor.Nombre;
            this.Apellido = repartidor.Apellido;
            this.CodigoPostal = repartidor.CodigoPostal;
            this.Latitud = repartidor.Latitud;
            this.Longitud = repartidor.Longitud;
            this.TelContacto = repartidor.TelContacto;
            this.PorcentajeComision = repartidor.PorcentajeComision;
           
        }
        public float PorcentajeComision { get; set; }
    }
}