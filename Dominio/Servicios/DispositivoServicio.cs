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
    public class DispositivoServicio
    {
        private readonly IDispositivo dispositivoRepositorio;

        public DispositivoServicio(IDispositivo dispositivoRepositorio)
        {
            this.dispositivoRepositorio = dispositivoRepositorio;
        }

        public void AgregarDispositivo(Dispositivo d)
        {

            try
            {
                string error = "";
                List<Dispositivo> checkeo = dispositivoRepositorio.GetAll();
                foreach (Dispositivo dis in checkeo)
                {
                    if (dis.Nombre.ToLower() == d.Nombre.ToLower() && dis.Id != d.Id)
                    {
                        error += "Ya existe un dispositivo con este nombre.";
                    }
                }
                if (error.Length == 0)
                {
                    d.FecAlta = DateTime.Now;
                    dispositivoRepositorio.Add(d);
                }
                else
                {
                    throw new DominioExepciones(error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new DominioExepciones("Error en el procesamiento de datos");
            }       
        }

        public void ActualizarDispositivo(Dispositivo d)
        {
            Dispositivo dispo = dispositivoRepositorio.GetById(d.Id);
            if (dispo == null)
            {
                throw new DominioExepciones("No existe un dispositivo con este id.");
            }
            try
            {
                string error = "";
                List<Dispositivo> checkeo = dispositivoRepositorio.GetAll();
                foreach(Dispositivo dis in checkeo)
                {
                    if (dis.Nombre.ToLower()==d.Nombre.ToLower() && dis.Id!= d.Id)
                    {
                        error += "Ya existe un dispositivo con este nombre.";
                    }
                }
                dispo.Detalle = d.Detalle;
                dispo.Estacion = d.Estacion;
                dispo.FecAlta = d.FecAlta;
                dispo.FecModificacion = DateTime.Now;
                dispo.Tipo = d.Tipo;
                dispo.Valor = d.Valor;
                dispo.Estado = d.Estado;
                if (error.Length > 2)
                {
                    throw new DominioExepciones(error);
                }
                else
                {
                    dispositivoRepositorio.Update(dispo);
                }
              
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new DominioExepciones("Error en el procesamiento de datos.");
            }

        }

        public void EliminarDispositivo(int Id)
        {
            dispositivoRepositorio.Delete(Id);
        }

        public List<Dispositivo> ListarDispositivos()
        {
            List<Dispositivo> dispositivos = dispositivoRepositorio.GetAll();
            return dispositivos;
        }

        public Dispositivo BuscarPorNombre(string nombre)
        {
            Dispositivo dispositivo = dispositivoRepositorio.GetByNombre(nombre);
            if (dispositivo == null)
            {
                throw new DominioExepciones("No existe un dispositivo con este nombre");
            }
            return dispositivo;
        }

        public Dispositivo BuscarPorId(int Id)
        {
            Dispositivo dispositivo = dispositivoRepositorio.GetById(Id);
            if (dispositivo == null)
            {
                throw new DominioExepciones("No existe un dispositivo con este Id");
            }
            return dispositivo;
        }

        public Task<Dispositivo> ObtenerAsync(int id)
        {
            Task<Dispositivo> dispositivo = dispositivoRepositorio.ObtenerAsync(id);
            if(dispositivo == null)
            {
                throw new DominioExepciones("No existe un dispositivo con este Id");
            }
            return dispositivo;
        }
    }
}
