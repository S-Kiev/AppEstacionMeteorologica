using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.Data
{
    public class NuestroContexto : DbContext
    {
        public NuestroContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Estacion> Estaciones { get; set; }
        public DbSet<TipoDispositivo> TiposDispositivos { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
