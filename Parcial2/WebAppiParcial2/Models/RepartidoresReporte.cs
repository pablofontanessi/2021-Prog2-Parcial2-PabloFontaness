using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppiParcial2.Models
{
    public class RepartidoresReporte
    {
        public RepartidoresReporte(Repartidor repartidor)
        {
            this.NombreApellido = repartidor.Nombre + " " + repartidor.Apellido;
            this.totalGanado = repartidor.Total;
            this.CantidadEnvios = repartidor.CantidadEnvios;
        }

        public string NombreApellido { get; set; }
        public int totalGanado { get; set; }
        public int CantidadEnvios { get; set; }

        public static List<RepartidoresReporte> Conversor(List<Repartidor> listaRepartidorFitrada)
        {
            List<RepartidoresReporte> repartidoresReportes = new List<RepartidoresReporte>();
            foreach (var repartidor in listaRepartidorFitrada)
            {
                RepartidoresReporte repartidores = new RepartidoresReporte(repartidor);
                repartidoresReportes.Add(repartidores);
            }
            return repartidoresReportes;
        }
    }
}