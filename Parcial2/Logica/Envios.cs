using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Envios
    {
        public Envios(string descripcionPaquete, int dniDestinatario, DateTime fechaEstimoEntrega)
        {
            this.NumeroEnvio = LogicaPrincipal.Instancia.ObtenerNumeroEnvio();
            this.DescripcionPaquete = descripcionPaquete;
            this.Destinatario = LogicaPrincipal.Instancia.ObtenerPersonaPorDNI(dniDestinatario);
            FechaEstimoEntrega = fechaEstimoEntrega;
        }
        public string DescripcionPaquete { get; set; }
        public string NumeroEnvio { get; set; }
        public Personas Destinatario { get; set; }
        public Repartidor Repartidor { get; set; }
        public int Estado { get; set; }
        public DateTime FechaEstimoEntrega { get; set; }
        public DateTime FechaEntrega { get; set; }

    }
}
