using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class LogicaPrincipal
    {
        private static LogicaPrincipal instancia = new LogicaPrincipal();
        private LogicaPrincipal()
        {
        }
        public static LogicaPrincipal Instancia { get { return instancia; } }





    }
}
