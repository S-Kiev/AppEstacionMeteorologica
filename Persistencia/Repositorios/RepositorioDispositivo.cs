using Dominio.Entidades;
using Dominio.Repositorios;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repositorios
{
    public class RepositorioDispositivo : IDispositivo
    {
        private readonly NuestroContexto contexto;

        public RepositorioDispositivo(NuestroContexto contexto)
        {
            this.contexto = contexto;
        }

        public void Add(Dispositivo dispositivo)
        {
            contexto.Dispositivos.Add(dispositivo);
            contexto.SaveChanges();
        }

        public void Delete(int Id)
        {
            contexto.Dispositivos.Remove(GetById(Id));
            contexto.SaveChanges();
        }

        public List<Dispositivo> GetAll()
        {
            return contexto.Dispositivos.Include(x=>x.Estacion).Include(y=>y.Tipo).ToList();
        }

        public Dispositivo GetById(int id)
        {
            return contexto.Dispositivos.Include(x => x.Estacion).Include(y => y.Tipo).Where(z => z.Id == id).FirstOrDefault();
        }

        public Dispositivo GetByNombre(string nombre)
        {
            return contexto.Dispositivos.FirstOrDefault(e => e.Nombre == nombre);
        }

        public async Task<Dispositivo> ObtenerAsync(int id)
        {
            return await contexto.Dispositivos.FindAsync(id);
        }

        public void Update(Dispositivo dispositivo)
        {
            contexto.Dispositivos.Attach(dispositivo);
            contexto.Entry(dispositivo).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
