using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Repartidor : Personas
    {
        public int PorcentajeComision { get; set; }
        public int CantidadEnvios { get; set; }
        public int Total { get; set; }
    }
}
