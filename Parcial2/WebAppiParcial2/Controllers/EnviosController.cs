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
    public class EnviosController : ApiController
    {
        public IHttpActionResult Post([FromBody] EnvioRequest envioRequest)
        {
            ResponseGeneral responseExiteDestinarario = new ResponseGeneral(LogicaPrincipal.Instancia.ExisteDestinatario(envioRequest.DniDestinatario));
            if (responseExiteDestinarario.Respuesta)
            {
                ResponseGeneral responseGeneral = new ResponseGeneral(LogicaPrincipal.Instancia.AltaEnvio(EnvioRequest.Conversor(envioRequest)));

                if (responseGeneral.Respuesta)
                {
                    EnvioResponse objResponse = new EnvioResponse(responseGeneral.id);
                    return Content(HttpStatusCode.Created, objResponse);
                }
                return Content(HttpStatusCode.BadRequest, responseGeneral.Detalle);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, responseExiteDestinarario.Detalle);
            }
           
        }
        public IHttpActionResult Put(string NumeroEnvio, [FromBody] int Estado)
        {
            
            ResponseGeneral responseGeneral = new ResponseGeneral(LogicaPrincipal.Instancia.ActualizarEnvio(NumeroEnvio,Estado));
            if (responseGeneral.Respuesta)
            {
                
                return Content(HttpStatusCode.OK,"Actualizado con exito");
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, responseGeneral.Detalle);
            }
        }

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

        public List<RepartidoresReporte> Get([FromBody] DateTime FechaDesde, DateTime FechaHasta)
        {
            Lista<Repartidor> listaRepartidorFitrada = LogicaPrincipal.Instancia.ObtenerListadoRepartidorPorFechA(FechaDesde, FechaHasta);   
        }

           
    }
}
