using Dominio.Entidades;
using Dominio.Exepciones;
using Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Servicios
{
    public class EstacionServicio
    {
        private readonly IEstacion estacionRepositorio;

        public EstacionServicio(IEstacion estacionRepositorio)
        {
            this.estacionRepositorio = estacionRepositorio;
        }

        public void AgregarEstacion(Estacion e)
        {
            try
            {
                string error = "";

                List<Estacion> checkeo = estacionRepositorio.GetAll();
                foreach (Estacion es in checkeo)
                {
                    if (es.Nombre.ToLower() == e.Nombre.ToLower() && es.Id != e.Id)
                    {
                        error += "Ya existe una estacion con este nombre.";
                    }

                }
                if (e.Latitud > 90 || e.Latitud < -90)
                {
                    error += " Latitud fuera de rango.";
                }

                if (e.Longitud > 180 || e.Longitud < -180)
                {
                    error += " Longitud fuera de rango.";
                }

                if (error.Length > 2)
                {
                    throw new DominioExepciones(error);
                }
                else
                {
                    estacionRepositorio.Add(e);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new DominioExepciones("Error en el procesamiento de datos");
            }
        }

        public void ActualizarEstacion(Estacion e)
        {
            Estacion estacion = estacionRepositorio.GetById(e.Id);

            if (estacion == null)
            {
                throw new DominioExepciones("No existe un Estación con este id");
            }

            try
            {
                string error = "";

                List<Estacion> checkeo = estacionRepositorio.GetAll();
                foreach(Estacion es in checkeo)
                {
                    if(es.Nombre.ToLower() == e.Nombre.ToLower() && es.Id != e.Id)
                    {
                        error += "Ya existe una estacion con este nombre.";
                    }

                }
                if(e.Latitud>90 || e.Latitud < -90)
                {
                    error += " Latitud fuera de rango.";
                }

                if(e.Longitud>180 || e.Longitud < -180)
                {
                    error += " Longitud fuera de rango.";
                }

                estacion.Nombre = e.Nombre;
                estacion.Latitud = e.Latitud;
                estacion.Longitud = e.Longitud;
                estacion.Supervisor = e.Supervisor;
                estacion.IdSupervisor = e.IdSupervisor;
                if(error.Length > 2)
                {
                    throw new DominioExepciones(error);
                }
                else
                {
                    estacionRepositorio.Update(estacion);
                }            
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new DominioExepciones("Error en el procesamiento de datos");
            }

        }

        public void EliminarEstacion(int Id)
        {
            estacionRepositorio.Delete(Id);
        }

        public List<Estacion> ListarEstaciones()
        {
            List<Estacion> estaciones = estacionRepositorio.GetAll();
            return estaciones;
        }

        public Estacion BuscarPorNombre(string nombre)
        {
            Estacion estacion = estacionRepositorio.GetByNombre(nombre);
            if (estacion == null)
            {
                throw new DominioExepciones("No existe una estación con este nombre");
            }
            return estacion;
        }

        public Estacion BuscarPorId(int Id)
        {
            Estacion estacion = estacionRepositorio.GetById(Id);
            if (estacion == null)
            {
                throw new DominioExepciones("No existe una estación con este Id");
            }
            return estacion;
        }
    }
}
