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
    public class UsuarioServicio
    {
        private IUsuario usuarioRepositorio;

        public UsuarioServicio(IUsuario usuarioRepositorio)
        {
            this.usuarioRepositorio = usuarioRepositorio;
        }


        public List<Usuario> ListarUsuario()
        {
            List<Usuario> usuario = usuarioRepositorio.GetAll();
            return usuario;
        }

        public Usuario BuscarPorNombre(string nombre)
        {
            Usuario usuario = usuarioRepositorio.GetByUser(nombre);
            if (usuario == null)
            {
                throw new DominioExepciones("No existe un usuario con este nombre");
            }
            return usuario;
        }

        public Usuario logearUsuario(string nombre, string pass)
        {
            Usuario usu = usuarioRepositorio.logearUsuario(nombre, pass);
            if (usu == null)
            {
                throw new DominioExepciones("No existen esas credenciales");
            }
            return usu;
        }

        public Usuario BuscarPorId(int Id)
        {
            Usuario usuario = usuarioRepositorio.GetById(Id);
            if (usuario == null)
            {
                throw new DominioExepciones("No existe un usuario con este Id");
            }
            return usuario;
        }
    }
}
