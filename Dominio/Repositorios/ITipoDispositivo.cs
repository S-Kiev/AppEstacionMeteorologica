using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface ITipoDispositivo
    {
        public void Add(TipoDispositivo td);
        public void Update(TipoDispositivo td);
        public void Delete(int id);
        public List<TipoDispositivo> GetAll();
        public TipoDispositivo GetById(int id);
        public TipoDispositivo GetByNombre(string nombre);
    }
}
