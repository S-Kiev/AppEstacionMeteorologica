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
    public class RepositorioEstacion : IEstacion
    {
        private readonly NuestroContexto contexto;

        public RepositorioEstacion(NuestroContexto contexto)
        {
            this.contexto = contexto;
        }

        public void Add(Estacion estacion)
        {
            contexto.Estaciones.Add(estacion);
            contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            contexto.Estaciones.Remove(GetById(id));
            contexto.SaveChanges();
        }

        public List<Estacion> GetAll()
        {
            return contexto.Estaciones.Include(x => x.Supervisor).ToList();
        }

        public Estacion GetById(int id)
        {
            return contexto.Estaciones.Include(x => x.Supervisor).Where(z => z.Id == id).FirstOrDefault();
            
        }

        public Estacion GetByNombre(string nombre)
        {
            return contexto.Estaciones.FirstOrDefault(x => x.Nombre == nombre);
        }

        public void Update(Estacion estacion)
        {
            contexto.Estaciones.Attach(estacion);
            contexto.Entry(estacion).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
