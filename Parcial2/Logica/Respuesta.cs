using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Respuesta
    {
        private static Respuesta respuesta = new Respuesta();
        private Respuesta()
        {
        }
        public static Respuesta RespuestaInstance { get { return respuesta; } }

        public bool Resultado { get; set; }
        public int Id { get; set; }
        public string Detalle { get; set; }
    }
}
