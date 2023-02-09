using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("TipoDispositivo")]
    public class TipoDispositivo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 200, MinimumLength = 10, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Descripcion { get; set; }
    }
}
