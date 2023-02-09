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
    public class TipoDispositivoServicio
    {
        private readonly ITipoDispositivo TDRepositorio;

        public TipoDispositivoServicio(ITipoDispositivo tDRepositorio)
        {
            TDRepositorio = tDRepositorio;
        }

        public void AgregarTipoDespositivo(TipoDispositivo td)
        {
            TipoDispositivo tipo = TDRepositorio.GetByNombre(td.Nombre);
            if (tipo != null)
            {
                throw new DominioExepciones("Ya existe un tipo de dispositivo con este nombre.");
            }
            try
            {
                TDRepositorio.Add(td);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new DominioExepciones("Error en el procesamiento de datos.");
            }
        }

        public void ActualizarTipoDispositivo(TipoDispositivo td)
        {
            TipoDispositivo tipo = TDRepositorio.GetById(td.Id);
            if (tipo == null)
            {
                throw new DominioExepciones("No existe un tipo de dispositivo con este id.");
            }
            try
            {
                List<TipoDispositivo> checkeo = TDRepositorio.GetAll();
                foreach (TipoDispositivo t in checkeo)
                {
                    if (t.Nombre.ToLower() == td.Nombre.ToLower() && t.Id != td.Id)
                    {
                        throw new DominioExepciones("Ya hay un tipo de dispositivo con este nombre.");
                    }
                }                

                tipo.Nombre = td.Nombre;
                tipo.Descripcion = td.Descripcion;
                TDRepositorio.Update(tipo);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new DominioExepciones("Error en el procesamiento de datos.");
            }
        }

        public void EliminarTipoDispositivo(int id)
        {
            TDRepositorio.Delete(id);
        }

        public List<TipoDispositivo> ListarTipoDispositivo()
        {
            List<TipoDispositivo> tipoDispositivos = TDRepositorio.GetAll();
            return tipoDispositivos;
        }

        public TipoDispositivo BuscarPorId(int id)
        {
            TipoDispositivo tipoDispositivo = TDRepositorio.GetById(id);
            if (tipoDispositivo == null)
            {
                throw new DominioExepciones("No existe un tipo de dispositivo con este id.");
            }
            return tipoDispositivo;

        }

        public TipoDispositivo BuscarPorNombre(string nombre)
        {
            TipoDispositivo tipoDispositivo = TDRepositorio.GetByNombre(nombre);
            if (tipoDispositivo == null)
            {
                throw new DominioExepciones("No existe un tipo de dispositivo con este nombre.");
            }
            return tipoDispositivo;
        }
    }
}
