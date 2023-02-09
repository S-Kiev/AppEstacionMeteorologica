using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Repositorios
{
    public interface IUsuario
    {
        public List<Usuario> GetAll();
        public Usuario GetById(int id);
        public Usuario GetByUser(string user);
        public Usuario logearUsuario(string nombre, string pass);
    }
}
