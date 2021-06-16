using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppiParcial2.Models;
using Logica;

namespace WebAppiParcial2.Controllers
{
    public class RepartidorController : ApiController
    {

        // SEPARE EN 2 LOS CONTROLERS PORQUE ME DABA ERROR EN EL SWAGGER AL TENER 2 POST. Entendi que debian ser distintos controladores.
        public IHttpActionResult Post(string NumeroEnvio)
        {
            ResponseGeneral responseGeneral = new ResponseGeneral(LogicaPrincipal.Instancia.ObtenerRepartidor(NumeroEnvio));

            if (responseGeneral.Respuesta)
            {
                RepartidorRequest repartidorRequest = new RepartidorRequest(LogicaPrincipal.Instancia.ObtenerRepartidorPorDNI(responseGeneral.id));
                return  Content(HttpStatusCode.OK, repartidorRequest);
            }
            
            return Content(HttpStatusCode.BadRequest, responseGeneral.Detalle);

        }

        public IHttpActionResult Get([FromBody] DateTime FechaDesde, DateTime FechaHasta)
        {
            List<Repartidor> listaRepartidorFitrada = LogicaPrincipal.Instancia.ObtenerListadoRepartidorPorFechA(FechaDesde, FechaHasta);
            List<RepartidoresReporte> listado =  RepartidoresReporte.Conversor(listaRepartidorFitrada);
            if (listado != null)
            {
                return Content(HttpStatusCode.OK, listado);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "No se encontro repartidor para esas fechas");
            }
        }

           
    }
}
