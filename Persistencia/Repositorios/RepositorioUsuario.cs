using Dominio.Entidades;
using Dominio.Repositorios;
using Persistencia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Repositorios
{
    public class RepositorioUsuario : IUsuario
    {
        private readonly NuestroContexto contexto;

        public RepositorioUsuario(NuestroContexto contexto)
        {
            this.contexto = contexto;
        }

        public List<Usuario> GetAll()
        {
            return contexto.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {
            return contexto.Usuarios.Find(id);
        }

        public Usuario GetByUser(string user)
        {
            return contexto.Usuarios.FirstOrDefault(x => x.NomUsuario == user);
        }

        public Usuario logearUsuario(string nombre, string pass)
        {
            return contexto.Usuarios.FirstOrDefault(u => u.NomUsuario == nombre && u.Pass == pass);
        }
    }
}
