using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Dominio.Repositorios
{
    public interface IDispositivo
    {
        public void Add(Dispositivo dispositivo);
        public void Update(Dispositivo dispositivo);
        public void Delete(int Id);
        public List<Dispositivo> GetAll();
        public Dispositivo GetById(int id);
        public Dispositivo GetByNombre(string nombre);
        public Task<Dispositivo> ObtenerAsync(int id);
       
    }
}
