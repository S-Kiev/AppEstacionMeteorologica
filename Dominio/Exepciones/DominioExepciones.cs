using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Exepciones
{
    public class DominioExepciones : Exception
    {
        public DominioExepciones(string? message) : base(message)
        {
        }
    }
}
