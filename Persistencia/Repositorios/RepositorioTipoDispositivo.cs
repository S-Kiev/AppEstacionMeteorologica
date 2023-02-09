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
    public class RepositorioTipoDispositivo : ITipoDispositivo
    {
        private readonly NuestroContexto contexto;

        public RepositorioTipoDispositivo(NuestroContexto contexto)
        {
            this.contexto = contexto;
        }

        public void Add(TipoDispositivo td)
        {
            contexto.TiposDispositivos.Add(td);
            contexto.SaveChanges();
        }

        public void Delete(int id)
        {
            var tipo = contexto.TiposDispositivos.Find(id);
            contexto.Entry(tipo).State = EntityState.Deleted;
            contexto.SaveChanges();
        }

        public List<TipoDispositivo> GetAll()
        {
            return contexto.TiposDispositivos.ToList();
        }

        public TipoDispositivo GetById(int id)
        {
            return contexto.TiposDispositivos.Find(id);
        }

        public TipoDispositivo GetByNombre(string nombre)
        {
            return contexto.TiposDispositivos.FirstOrDefault(x => x.Nombre == nombre);
        }

        public void Update(TipoDispositivo td)
        {
            contexto.TiposDispositivos.Attach(td);
            contexto.Entry(td).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
