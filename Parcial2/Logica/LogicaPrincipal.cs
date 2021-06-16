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

        
        public string ObtenerNumeroEnvio()
        {
            Random random = new Random();
            do
            {
                if (ListadoEnvios.Find(x => x.NumeroEnvio == random.ToString()) == null)
                {
                    string numeroEnvio = random.ToString();
                    return numeroEnvio;
                }
                random.Next();

            } while (ListadoEnvios.Find(x => x.NumeroEnvio == random.ToString()) != null);

            return random.ToString();
            
        }

        public Respuesta ExisteDestinatario(int dniDestinatario)
        {
            if (listadoPersonas.Find(x => x.Dni==dniDestinatario) != null )
            {
                if (listadoPersonas.Find(x => x.Dni == dniDestinatario).TelContacto != null)
                {
                    Respuesta.RespuestaInstance.Resultado = true;
                    return Respuesta.RespuestaInstance;
                }
                else
                {
                    Respuesta.RespuestaInstance.Resultado = false;
                    Respuesta.RespuestaInstance.Detalle = "No tiene numero de contacto";
                    return Respuesta.RespuestaInstance;
                }
            }
            Respuesta.RespuestaInstance.Resultado = false;
            Respuesta.RespuestaInstance.Detalle = "No existe destinatario";
            return Respuesta.RespuestaInstance;
        }

        public Respuesta ActualizarEnvio(string numeroEnvio, int estado)
        {
            switch (estado)
            {
                case 1:
                    if (ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado != 1)
                    {
                        ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado = 1;
                        Respuesta.RespuestaInstance.Resultado = true;
                        return Respuesta.RespuestaInstance;
                    }
                    Respuesta.RespuestaInstance.Resultado = true;
                    return Respuesta.RespuestaInstance;
                    
                case 2:
                    if (ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado != 2)
                    {
                        ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado = 2;
                        Respuesta.RespuestaInstance.Resultado = true;
                        return Respuesta.RespuestaInstance;
                    }
                    Respuesta.RespuestaInstance.Resultado = true;
                    return Respuesta.RespuestaInstance;
                   

                case 3:
                    if (ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado != 3)
                    {
                        ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado = 3;
                        Respuesta.RespuestaInstance.Resultado = true;
                        return Respuesta.RespuestaInstance;
                    }
                    Respuesta.RespuestaInstance.Resultado = true;
                    return Respuesta.RespuestaInstance;
                    
                case 4:
                    if (ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado != 4)
                    {
                        ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Estado = 4;
                        ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).FechaEntrega = DateTime.Today;
                        int DNI = ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio).Repartidor.Dni;
                        ListadoRepartidores.Find(x => x.Dni == DNI).CantidadEnvios += 1;
                        if (ListadoRepartidores.Find(x => x.Dni == DNI).Total != 0)
                        {
                            int total = ListadoRepartidores.Find(x => x.Dni == DNI).Total * ListadoRepartidores.Find(x => x.Dni == DNI).PorcentajeComision;
                            ListadoRepartidores.Find(x => x.Dni == DNI).Total = total;
                        }
                        else
                        {
                            
                            int total =  10 * ListadoRepartidores.Find(x => x.Dni == DNI).PorcentajeComision;
                            ListadoRepartidores.Find(x => x.Dni == DNI).Total = total;
                        }
                        
                        Respuesta.RespuestaInstance.Resultado = true;
                        return Respuesta.RespuestaInstance;
                    }
                    Respuesta.RespuestaInstance.Resultado = true;
                    return Respuesta.RespuestaInstance;
                    
                default:
                    Respuesta.RespuestaInstance.Resultado = false;
                    Respuesta.RespuestaInstance.Detalle = "Numero Estado invalido";
                    return Respuesta.RespuestaInstance;
                    break;
            }
        }

        public List<Repartidor> ObtenerListadoRepartidorPorFechA(DateTime fechaDesde, DateTime fechaHasta)
        {
            List<Repartidor> ListaFiltrada = ListadoRepartidores;
            foreach (var envio in ListadoEnvios)
            {
                if (envio.FechaEstimoEntrega > fechaDesde && envio.FechaEstimoEntrega < fechaHasta && envio.Estado == 4)
                {
                    ListaFiltrada.Add(envio.Repartidor);
                }
            }
            return ListaFiltrada;
        }

        public Repartidor ObtenerRepartidorPorDNI(string id)
        {
            return ListadoRepartidores.Find(x => x.Dni == int.Parse(id));
        }

        public Respuesta ObtenerRepartidor(string numeroEnvio)
        {

            Envios envio = ObtenerEnvioPorNumero(numeroEnvio);
            if (envio != null)
            {
                double DistanciaMin = 100000000;
                int DNIRepartidor = 0;
                double disntanciaParcial = 0;
                foreach (var repartidor in ListadoRepartidores)
                {
                    disntanciaParcial = CaluclarDitancia(envio.Destinatario, repartidor);
                    if (disntanciaParcial < DistanciaMin)
                    {
                        DistanciaMin = disntanciaParcial;
                        DNIRepartidor = repartidor.Dni;
                    }
                }
                Respuesta.RespuestaInstance.Resultado = true;
                Respuesta.RespuestaInstance.Id = DNIRepartidor.ToString();
                return Respuesta.RespuestaInstance;
            }
            Respuesta.RespuestaInstance.Resultado = false;
            Respuesta.RespuestaInstance.Detalle = "no existe envio";
            return Respuesta.RespuestaInstance;
            
        }

        private double CaluclarDitancia(Personas Destinatario, Repartidor repartidor)
        {
            int EarthRadius = 6371; //en KM
            double distance = 0;
            double Lat = (repartidor.Latitud - Destinatario.Latitud) * (Math.PI / 180);
            double Lon = (repartidor.Longitud - Destinatario.Longitud) * (Math.PI / 180);
            double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(Destinatario.Latitud * (Math.PI / 180)) * Math.Cos(repartidor.Latitud * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            distance = EarthRadius * c;
            return distance;
        }

        private Envios ObtenerEnvioPorNumero(string numeroEnvio)
        {
            return ListadoEnvios.Find(x => x.NumeroEnvio == numeroEnvio);
        }

        public List<Personas> listadoPersonas = new List<Personas>();
        public List<Envios> ListadoEnvios = new List<Envios>();
        public List<Repartidor> ListadoRepartidores = new List<Repartidor>();
        public Respuesta AltaEnvio(Envios envios)
        {
            if (ListadoEnvios.Find(x => x.NumeroEnvio == envios.NumeroEnvio) != null)
            {
                Respuesta.RespuestaInstance.Resultado = false;
                Respuesta.RespuestaInstance.Detalle = $"El objeto con id: {envios.NumeroEnvio} ya se encuentra";
                return Respuesta.RespuestaInstance;
            }
            else
            {
                envios.Estado = 1;
                ListadoEnvios.Add(envios);
                Respuesta.RespuestaInstance.Resultado = true;
                Respuesta.RespuestaInstance.Id = envios.NumeroEnvio;
                return Respuesta.RespuestaInstance;
            }
        }
        public Personas ObtenerPersonaPorDNI(int dniDestinatario)
        {
            return listadoPersonas.Find(x => x.Dni == dniDestinatario);
        }
    }
}
