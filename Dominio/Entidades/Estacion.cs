using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    [Table("Estacion")]
    public class Estacion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        [StringLength(maximumLength: 100, MinimumLength = 10, ErrorMessage = "El {0} debe tener minimo {2} letras y un maximo de {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La {0} es obligatoria")]
        [Range(-90, 90, ErrorMessage = "La {0} debe estar entre {1} y {2}")]
        public float Latitud { get; set; }

        [Required(ErrorMessage = "La {0} es obligatoria")]
        [Range(-180, 180, ErrorMessage = "La {0} debe estar entre {1} y {2}")]
        public float Longitud { get; set; }

        public Usuario Supervisor { get; set; }

        [ForeignKey("Supervisor")]
        public int? IdSupervisor { get; set; }
    }
}
