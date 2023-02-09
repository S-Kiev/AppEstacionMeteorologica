using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IEstacion
    {
        public void Add(Estacion estacion);
        public void Update(Estacion estacion);
        public void Delete(int id);
        public List<Estacion> GetAll();
        public Estacion GetById(int id);
        public Estacion GetByNombre(string nombre);

    }
}
